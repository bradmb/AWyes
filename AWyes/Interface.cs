using Amazon;
using Amazon.EC2;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime;
using AWyes.Model;
using System.Diagnostics;
using OtpNet;
using AWyes.Properties;
using Ookii.Dialogs.WinForms;
using System.Security.Cryptography;
using Amazon.RDS;

namespace AWyes
{
    public partial class Interface : ExtendedForm
    {
        /// <summary>
        /// The AWS EC2 client
        /// </summary>
        private AmazonEC2Client? _ec2Client;

        /// <summary>
        /// The AWS RDS client
        /// </summary>
        private AmazonRDSClient? _rdsClient;

        /// <summary>
        /// The list of instances available for the selected region
        /// </summary>
        private readonly List<EC2ListItem> _instanceSelector = new();

        /// <summary>
        /// The list of RDS instances available for the selected region
        /// </summary>
        private readonly List<RDSListItem> _rdsInstanceSelector = new();

        /// <summary>
        /// The next available port we will be opening a tunnel on (for Windows instances)
        /// </summary>
        private int _currentLocalPort = 55670;

        /// <summary>
        /// The user's data encryption key, entered at application startup
        /// </summary>
        private string? _encryptionKey;

        /// <summary>
        /// The currently selected EC2 instance
        /// </summary>
        private EC2ListItem? _selectedInstance;

        /// <summary>
        /// The currently selected RDS instance
        /// </summary>
        private RDSListItem? _selectedRDSInstance;

        /// <summary>
        /// The currently selected region
        /// </summary>
        private string? _selectedRegion;

        public Interface()
        {
            InitializeComponent();

            //
            // Show a message asking for the user's encryption passphrase
            //
            while (string.IsNullOrWhiteSpace(_encryptionKey))
            {
                //
                // Setup our encryption IV if not configured
                //
                if (string.IsNullOrWhiteSpace(Settings.Default.EncryptionIV))
                {
                    Settings.Default.EncryptionIV = Guid.NewGuid().ToString("N").Substring(0, 16);
                    Settings.Default.Save();
                }

                var passphraseEntry = new InputDialog
                {
                    UsePasswordMasking = true,
                    MainInstruction = "Please Enter Your Passphrase",
                    Content = "To keep your configuration secure, all data is encrypted using this passphrase. To continue, please enter your passphrase below.",
                    WindowTitle = "AW(yes) - Passphrase Entry"
                };

                var passphraseEntryResult = passphraseEntry.ShowDialog();

                //
                // If the entry was completed, do a quick decryption
                // check to make sure it's correct (assuming this is not
                // the initial startup)
                //
                if (passphraseEntryResult == DialogResult.OK && !string.IsNullOrWhiteSpace(passphraseEntry.Input))
                {
                    //
                    // Store the key in memory
                    //
                    _encryptionKey = passphraseEntry.Input;

                    //
                    // Now perform our decryption check if we've done
                    // this before
                    //
                    if (!string.IsNullOrWhiteSpace(Settings.Default.EncryptionCheck))
                    {
                        try
                        {
                            Encryption.DecryptLocal(Settings.Default.EncryptionCheck, _encryptionKey, Settings.Default.EncryptionIV);
                        }
                        catch (CryptographicException)
                        {
                            //
                            // If they failed to enter the correct key, let them know and give
                            // them the option to wipe and reload
                            //
                            _encryptionKey = null;

                            var badKeyDialog = new Ookii.Dialogs.WinForms.TaskDialog
                            {
                                AllowDialogCancellation = true,
                                Content = "The passphrase you entered does not match the one used to encrypt your configuration. Please try again.",
                                ButtonStyle = TaskDialogButtonStyle.CommandLinks
                            };

                            badKeyDialog.Buttons.Add(new Ookii.Dialogs.WinForms.TaskDialogButton
                            {
                                Text = "Try Again",
                                CommandLinkNote = "Allows you to try and re-enter your passhrase again",
                                ElevationRequired = false
                            });

                            badKeyDialog.Buttons.Add(new Ookii.Dialogs.WinForms.TaskDialogButton
                            {
                                Text = "Reset Your Settings",
                                CommandLinkNote = "This will wipe out all of your current settings, but will allow you to setup a new passphrase and start from scratch.",
                                ElevationRequired = true
                            });

                            var errorMessageResult = badKeyDialog.ShowDialog();
                            if (errorMessageResult?.Text == "Reset Your Settings")
                            {
                                Settings.Default.Reset();
                                Settings.Default.Save();
                            }
                        }
                    }
                    else
                    {
                        Settings.Default.EncryptionCheck = Encryption.EncryptLocal("good-to-go", _encryptionKey, Settings.Default.EncryptionIV);
                        Settings.Default.Save();
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }

            //
            // Load in the data from the settings (if found)
            //
            if (!string.IsNullOrWhiteSpace(Settings.Default.ProfileName))
            {
                ProfileNameInput.Text = Encryption.DecryptLocal(Settings.Default.ProfileName, _encryptionKey, Settings.Default.EncryptionIV);
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.ProfileNameAdmin))
            {
                ProfileNameAdminInput.Text = Encryption.DecryptLocal(Settings.Default.ProfileNameAdmin, _encryptionKey, Settings.Default.EncryptionIV);
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.OneTimePasswordKey))
            {
                OneTimePasswordSecret.Text = Encryption.DecryptLocal(Settings.Default.OneTimePasswordKey, _encryptionKey, Settings.Default.EncryptionIV);
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.CloudflaredInstallLocation))
            {
                CloudflareInstallationLocationInput.Text = Encryption.DecryptLocal(Settings.Default.CloudflaredInstallLocation, _encryptionKey, Settings.Default.EncryptionIV);
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.PortForwardingDocumentName))
            {
                PortForwardingDocumentInput.Text = Encryption.DecryptLocal(Settings.Default.PortForwardingDocumentName, _encryptionKey, Settings.Default.EncryptionIV);
            }
        }

        /// <summary>
        /// Update the EC2 client based on the selected region
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private async void RegionSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            var regionText = RegionSelector.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(regionText))
            {
                _ec2Client = null;
                _rdsClient = null;
                _selectedRegion = null;

                return;
            }

            _selectedRegion = regionText;
            var region = RegionEndpoint.GetBySystemName(regionText);

            var chain = new CredentialProfileStoreChain();
            if (chain.TryGetAWSCredentials(ProfileNameInput.Text, out AWSCredentials awsCredentials))
            {
                _ec2Client = new AmazonEC2Client(awsCredentials, region);
                _rdsClient = new AmazonRDSClient(awsCredentials, region);
            }

            await PopulateInstanceListAsync();
        }

        /// <summary>
        /// Populates the EC2 instance list
        /// </summary>
        /// <returns>A task</returns>
        private async Task PopulateInstanceListAsync()
        {
            if (_ec2Client == null || _rdsClient == null)
            {
                return;
            }

            _instanceSelector.Clear();
            _rdsInstanceSelector.Clear();

            InstanceListBox.DataSource = null;
            RDSInstanceListBox.DataSource = null;

            //
            // Load EC2 Instance Data
            //
            var ec2InstanceData = await _ec2Client.DescribeInstancesAsync();
            foreach (var reservation in ec2InstanceData.Reservations)
            {
                foreach (var instance in reservation.Instances.Where(i => i.State.Name.Value != "stopped"))
                {
                    _instanceSelector.Add(new EC2ListItem(instance));
                }
            }

            //
            // Load RDS Instance Data
            //
            var rdsInstanceData = await _rdsClient.DescribeDBInstancesAsync();
            foreach (var instance in rdsInstanceData.DBInstances.Where(i => i.DBInstanceStatus != "stopped"))
            {
                _rdsInstanceSelector.Add(new RDSListItem(instance));
            }

            InstanceListBox.DisplayMember = "DisplayName";
            InstanceListBox.DataSource = _instanceSelector;

            RDSInstanceListBox.DisplayMember = "DisplayName";
            RDSInstanceListBox.DataSource = _rdsInstanceSelector;

            ClearSelectionsAndResetButtons();
        }

        /// <summary>
        /// Gets information about the selected instance
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void InstanceListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (InstanceListBox.SelectedItem == null)
            {
                return;
            }

            _selectedInstance = InstanceListBox.SelectedItem as EC2ListItem;
            if (_selectedInstance == null)
            {
                return;
            }

            ConnectToInstanceButton.Enabled = true;
            RemoteDesktopButton.Enabled = _selectedInstance.InstanceType == EC2InstanceType.Windows;
            PortForwardToInstanceButton.Enabled = _selectedInstance.InstanceData.Tags?.Any(t => t.Key == "developer-params" && t.Value.Contains("port-forwarding")) == true;
        }

        /// <summary>
        /// Establishes a tunnel to an EC2 instance
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void ConnectToInstanceButton_Click(object sender, EventArgs e)
        {
            if (InstanceTypeTab.SelectedTab.Name == "EC2Tab" && _selectedInstance != null)
            {
                //
                // Determine if it is a Windows or Linux box and then route
                // the connection logic to the appropriate method
                //
                var instanceData = _selectedInstance.InstanceData;
                switch (_selectedInstance.InstanceType)
                {
                    case EC2InstanceType.Windows:
                        ConnectToWindowsInstance();
                        break;

                    case EC2InstanceType.Linux:
                        ConnectToLinuxInstance();
                        break;

                    default:
                        MessageBox.Show($"Unknown Instance Type: {instanceData.Platform?.Value ?? instanceData.PlatformDetails}");
                        return;
                }
            }
            else if (InstanceTypeTab.SelectedTab.Name == "RDSTab" && _selectedRDSInstance != null)
            {
                ConnectToRDSMSSQLInstance();
            }
        }

        /// <summary>
        /// Opens a tunnel to a Windows instance
        /// </summary>
        private void ConnectToWindowsInstance()
        {
            var connectionData = GetBaseEC2InstanceConnectionData();
            if (connectionData == null)
            {
                return;
            }

            var command = $"/K aws-vault exec {connectionData.ProfileName}{connectionData.MultiFactorFlag} -- aws ssm start-session --region {connectionData.Region} --target {connectionData.InstanceId} --document-name AWS-StartPortForwardingSession --parameters \"localPortNumber={connectionData.LocalPort},portNumber=3389\"";
            Process.Start("cmd.exe", command);
        }

        /// <summary>
        /// Opens a tunnel to a Linux instance
        /// </summary>
        private void ConnectToLinuxInstance()
        {
            var connectionData = GetBaseEC2InstanceConnectionData();
            if (connectionData == null)
            {
                return;
            }

            var command = $"/K aws-vault exec {connectionData.ProfileName}{connectionData.MultiFactorFlag} -- aws ssm start-session --target {connectionData.InstanceId}";
            Process.Start("cmd.exe", command);
        }

        /// <summary>
        /// Opens a tunnel to a RDS MS-SQL instance
        /// </summary>
        private void ConnectToRDSMSSQLInstance()
        {
            var connectionData = GetBaseRDSInstanceConnectionData();
            if (connectionData == null)
            {
                return;
            }

            var command = $"/K aws-vault exec {connectionData.ProfileName}{connectionData.MultiFactorFlag} -- aws ssm start-session --region {connectionData.Region} --target {connectionData.TunnelInstanceId} --document-name AWS-StartPortForwardingSessionToRemoteHost --parameters host=\"{connectionData.EndpointAddress}\",portNumber=\"{connectionData.ServerPort}\",localPortNumber=\"{connectionData.LocalPort}\"";
            Process.Start("cmd.exe", command);
        }

        /// <summary>
        /// Establishes a Remote Desktop connection to an EC2 instance
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void RemoteDesktopButton_Click(object sender, EventArgs e)
        {
            if (_selectedInstance == null)
            {
                return;
            }

            var localPort = _selectedInstance.ActiveConnectionPortNumber;

            var command = $"/c mstsc /v:127.0.0.1:{localPort} /prompt";
            Process.Start("cmd.exe", command);
        }

        /// <summary>
        /// Gets the information needed to connect to any instance type
        /// </summary>
        private EC2InstanceConnectionData? GetBaseEC2InstanceConnectionData()
        {
            if (_selectedInstance == null || string.IsNullOrWhiteSpace(_selectedRegion))
            {
                return null;
            }

            var instanceData = _selectedInstance.InstanceData;
            _selectedInstance.ActiveConnectionPortNumber = _currentLocalPort++;
            _selectedInstance.PortForwardingConnectionPortNumber = _currentLocalPort++;

            //
            // Get our configuration data points
            //
            var connectionData = new EC2InstanceConnectionData
            {
                LocalPort = _selectedInstance.ActiveConnectionPortNumber.Value,
                PortForwardingLocalPort = _selectedInstance.PortForwardingConnectionPortNumber.Value,
                InstanceId = instanceData.InstanceId,
                Region = _selectedRegion,
                ProfileName = ProfileNameInput.Text
            };

            if (!string.IsNullOrWhiteSpace(ProfileNameAdminInput.Text))
            {
                connectionData.ProfileName = ProfileNameAdminInput.Text;
            }

            //
            // Add the MFA attribute and value if we have one
            //
            connectionData.MultiFactorFlag = GenerateMultiFactorAttribute();

            return connectionData;
        }

        /// <summary>
        /// Gets the information needed to connect to any RDS instance type
        /// </summary>
        private RDSInstanceConnectionData? GetBaseRDSInstanceConnectionData()
        {
            if (_selectedRDSInstance == null || string.IsNullOrWhiteSpace(_selectedRegion))
            {
                return null;
            }

            var instanceData = _selectedRDSInstance.InstanceData;
            _selectedRDSInstance.ActiveConnectionPortNumber = _currentLocalPort++;
            _selectedRDSInstance.PortForwardingConnectionPortNumber = _currentLocalPort++;

            var tunnelInstanceId = instanceData.TagList.First(tl => tl.Key == "port-forwarding-instance").Value;

            //
            // Get our configuration data points
            //
            var connectionData = new RDSInstanceConnectionData
            {
                LocalPort = 1433,
                ServerPort = 1433,
                TunnelInstanceId = tunnelInstanceId,
                EndpointAddress = instanceData.Endpoint.Address,
                Region = _selectedRegion,
                ProfileName = ProfileNameInput.Text
            };

            if (!string.IsNullOrWhiteSpace(ProfileNameAdminInput.Text))
            {
                connectionData.ProfileName = ProfileNameAdminInput.Text;
            }

            //
            // Add the MFA attribute and value if we have one
            //
            connectionData.MultiFactorFlag = GenerateMultiFactorAttribute();

            return connectionData;
        }

        /// <summary>
        /// Generates the multi-factor authentication attribute/value, assuming
        /// the user has this configured in the interface
        /// </summary>
        /// <returns>The MFA attribute and value, if generated. Otherwise an empty string</returns>
        private string GenerateMultiFactorAttribute()
        {
            var mfaFlag = string.Empty;

            if (!string.IsNullOrWhiteSpace(OneTimePasswordSecret.Text))
            {
                var totp = new Totp(Base32Encoding.ToBytes(OneTimePasswordSecret.Text.Trim()));
                var totpCode = totp.ComputeTotp();

                mfaFlag = $" --mfa-token {totpCode}";
            }

            return mfaFlag;
        }

        /// <summary>
        /// Updates the profile name configuration
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void ProfileNameInput_TextChanged(object sender, EventArgs e)
        {
            if (_encryptionKey == null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(ProfileNameInput.Text))
            {
                Settings.Default.ProfileName = Encryption.EncryptLocal(ProfileNameInput.Text, _encryptionKey, Settings.Default.EncryptionIV);
            }
            else
            {
                Settings.Default.ProfileName = string.Empty;
            }

            Settings.Default.Save();
        }

        /// <summary>
        /// Updates the admin profile name configuration
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void ProfileNameAdminInput_TextChanged(object sender, EventArgs e)
        {
            if (_encryptionKey == null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(ProfileNameAdminInput.Text))
            {
                Settings.Default.ProfileNameAdmin = Encryption.EncryptLocal(ProfileNameAdminInput.Text, _encryptionKey, Settings.Default.EncryptionIV);
            }
            else
            {
                Settings.Default.ProfileNameAdmin = string.Empty;
            }

            Settings.Default.Save();
        }

        /// <summary>
        /// Updates the one time password key configuration
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void OneTimePasswordSecret_TextChanged(object sender, EventArgs e)
        {
            if (_encryptionKey == null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(OneTimePasswordSecret.Text))
            {
                Settings.Default.OneTimePasswordKey = Encryption.EncryptLocal(OneTimePasswordSecret.Text, _encryptionKey, Settings.Default.EncryptionIV);
            }
            else
            {
                Settings.Default.OneTimePasswordKey = string.Empty;
            }

            Settings.Default.Save();
        }

        /// <summary>
        /// Opens the AWS web console interface
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void OpenAwsConsoleButton_Click(object sender, EventArgs e)
        {
            var profileName = ProfileNameInput.Text;
            if (!string.IsNullOrWhiteSpace(ProfileNameAdminInput.Text))
            {
                profileName = ProfileNameAdminInput.Text;
            }

            if (string.IsNullOrWhiteSpace(profileName))
            {
                return;
            }

            //
            // Grab the MFA attribute and value if we have one
            //
            var mfaFlag = GenerateMultiFactorAttribute();

            var command = $"/c aws-vault login {profileName} --duration=4h{mfaFlag}";
            Process.Start("cmd.exe", command);
        }

        /// <summary>
        /// Creates a new Cloudflare tunnel (via cloudflared executable)
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void CloudflareOpenTunnelButton_Click(object sender, EventArgs e)
        {
            var installationPath = CloudflareInstallationLocationInput.Text;
            if (string.IsNullOrWhiteSpace(installationPath) || !File.Exists(installationPath))
            {
                return;
            }

            var tunnelPort = "44300";
            if (!string.IsNullOrWhiteSpace(CloudflareDestinationPortInput.Text))
            {
                tunnelPort = CloudflareDestinationPortInput.Text;
            }

            var command = $"/c {installationPath} tunnel --url https://localhost:{tunnelPort} --http-host-header localhost --no-tls-verify true";
            Process.Start("cmd.exe", command);
        }

        /// <summary>
        /// Opens a dialog box to locate the cloudflared executable
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void CloudflareInstallationLocationFinderButton_Click(object sender, EventArgs e)
        {
            var locationResult = CloudflareInstallationBrowserDialog.ShowDialog();
            if (locationResult == DialogResult.OK
                && !string.IsNullOrWhiteSpace(CloudflareInstallationBrowserDialog.FileName)
                && File.Exists(CloudflareInstallationBrowserDialog.FileName))
            {
                CloudflareInstallationLocationInput.Text = CloudflareInstallationBrowserDialog.FileName;

                //
                // Save into the settings
                //
                if (_encryptionKey == null)
                {
                    return;
                }

                Settings.Default.CloudflaredInstallLocation = Encryption.EncryptLocal(CloudflareInstallationBrowserDialog.FileName, _encryptionKey, Settings.Default.EncryptionIV);
                Settings.Default.Save();
            }
            else
            {
                Settings.Default.CloudflaredInstallLocation = string.Empty;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// Deletes all files in the Temporary ASP.NET Files folder
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void DeleteTempFilesButton_Click(object sender, EventArgs e)
        {
            const string command = @"/c del /s /q ""%tmp%\Temporary ASP.NET Files"" && rmdir /s /q ""%tmp%\Temporary ASP.NET Files\root"" && rmdir /s /q ""%tmp%\Temporary ASP.NET Files\vs""";

            var deleteConfirmationDialog = new Ookii.Dialogs.WinForms.TaskDialog
            {
                WindowTitle = "AW(yes) - Confirmation",
                AllowDialogCancellation = true,
                Content = "Are you sure that you want to delete your Temporary ASP.NET Files folder? This will delete every single file in that folder, leaving nothing behind (unless we run into a locked file).",
                MainInstruction = "Temporary ASP.NET Files Purge",
                ButtonStyle = TaskDialogButtonStyle.Standard,
                FooterIcon = Ookii.Dialogs.WinForms.TaskDialogIcon.Warning,
                Footer = $"The following command will be run:{Environment.NewLine} {command}",
                Width = 250,
                ExpandFooterArea = false
            };

            deleteConfirmationDialog.Buttons.Add(new Ookii.Dialogs.WinForms.TaskDialogButton
            {
                Text = "Yes, Delete Temporary ASP.NET Files",
                CommandLinkNote = "A window will appear, deleting the files. Once the window closes, your files have been deleted.",
                ElevationRequired = true
            });

            deleteConfirmationDialog.Buttons.Add(new Ookii.Dialogs.WinForms.TaskDialogButton
            {
                Text = "No, Cancel",
                CommandLinkNote = "Aborts the deletion of your files.",
                ElevationRequired = false
            });

            var deleteConfirmationResult = deleteConfirmationDialog.ShowDialog();
            if (deleteConfirmationResult?.Text == "Yes, Delete Temporary ASP.NET Files")
            {
                Process.Start("cmd.exe", command);
            }
        }

        /// <summary>
        /// Updates the port forwarding document name configuration
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void PortForwardingDocumentInput_TextChanged(object sender, EventArgs e)
        {
            if (_encryptionKey == null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(PortForwardingDocumentInput.Text))
            {
                Settings.Default.PortForwardingDocumentName = Encryption.EncryptLocal(PortForwardingDocumentInput.Text, _encryptionKey, Settings.Default.EncryptionIV);
            }
            else
            {
                Settings.Default.PortForwardingDocumentName = string.Empty;
            }

            Settings.Default.Save();
        }

        /// <summary>
        /// Establishes a port forwarding route to the selected instance
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void PortForwardToInstanceButton_Click(object sender, EventArgs e)
        {
            var connectionData = GetBaseEC2InstanceConnectionData();
            if (connectionData == null)
            {
                return;
            }

            var portForwardingDocumentName = "AWS-StartPortForwardingSession";
            if (!string.IsNullOrWhiteSpace(PortForwardingDocumentInput.Text))
            {
                portForwardingDocumentName = PortForwardingDocumentInput.Text;
            }

            var command = $"/K aws-vault exec {connectionData.ProfileName}{connectionData.MultiFactorFlag} -- aws ssm start-session --target {connectionData.InstanceId} --document-name {portForwardingDocumentName} --parameters \"localPortNumber={connectionData.PortForwardingLocalPort}\"";
            Process.Start("cmd.exe", command);
        }

        /// <summary>
        /// Gets information about the selected RDS instance
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void RDSInstanceListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (RDSInstanceListBox.SelectedItem == null)
            {
                return;
            }

            _selectedRDSInstance = RDSInstanceListBox.SelectedItem as RDSListItem;
            if (_selectedRDSInstance == null)
            {
                return;
            }

            var hasPortForwardingFlag = _selectedRDSInstance.InstanceData.TagList?.Any(t => t.Key == "developer-params" && t.Value.Contains("port-forwarding")) == true;
            var hasTunnelInstanceSpecified = _selectedRDSInstance.InstanceData.TagList?.Any(t => t.Key == "port-forwarding-instance" && !string.IsNullOrWhiteSpace(t.Value)) == true;

            ConnectToInstanceButton.Enabled = _selectedRDSInstance.InstanceType == RDSInstanceType.SQLServer
                && hasPortForwardingFlag
                && hasTunnelInstanceSpecified;

            RemoteDesktopButton.Enabled = false;
            PortForwardToInstanceButton.Enabled = false;
        }

        /// <summary>
        /// Removes any instance selections when the tabs change and disables all the buttons
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void InstanceTypeTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelectionsAndResetButtons();
        }

        /// <summary>
        /// Clears all instance selections and disables all buttons
        /// </summary>
        private void ClearSelectionsAndResetButtons()
        {
            ConnectToInstanceButton.Enabled = false;
            RemoteDesktopButton.Enabled = false;
            PortForwardToInstanceButton.Enabled = false;

            InstanceListBox.SelectedIndex = -1;
            RDSInstanceListBox.SelectedIndex = -1;
        }
    }
}