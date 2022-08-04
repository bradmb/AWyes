namespace AWyes
{
    partial class Interface
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interface));
            this.InterfaceTabControl = new System.Windows.Forms.TabControl();
            this.InterfaceAwsTab = new System.Windows.Forms.TabPage();
            this.InstanceTypeTab = new System.Windows.Forms.TabControl();
            this.EC2Tab = new System.Windows.Forms.TabPage();
            this.InstanceListBox = new System.Windows.Forms.ListBox();
            this.RDSTab = new System.Windows.Forms.TabPage();
            this.RDSInstanceListBox = new System.Windows.Forms.ListBox();
            this.PortForwardToInstanceButton = new System.Windows.Forms.Button();
            this.PortForwardingDocumentHeaderLabel = new System.Windows.Forms.Label();
            this.PortForwardingDocumentDescriptionLabel = new System.Windows.Forms.Label();
            this.PortForwardingDocumentLabel = new System.Windows.Forms.Label();
            this.PortForwardingDocumentInput = new System.Windows.Forms.TextBox();
            this.OpenAwsConsoleButton = new System.Windows.Forms.Button();
            this.WhatsThisHeaderLabel = new System.Windows.Forms.Label();
            this.OneTimePasswordDescriptionHeaderLabel = new System.Windows.Forms.Label();
            this.OneTimePasswordDescriptionLabel = new System.Windows.Forms.Label();
            this.InstanceListLabel = new System.Windows.Forms.Label();
            this.WhatsThisForLabel = new System.Windows.Forms.Label();
            this.ProfileNameLabel = new System.Windows.Forms.Label();
            this.ProfileNameInput = new System.Windows.Forms.TextBox();
            this.ProfileNameAdminLabel = new System.Windows.Forms.Label();
            this.ProfileNameAdminInput = new System.Windows.Forms.TextBox();
            this.OneTimePasswordLabel = new System.Windows.Forms.Label();
            this.OneTimePasswordSecret = new System.Windows.Forms.TextBox();
            this.RemoteDesktopButton = new System.Windows.Forms.Button();
            this.ConnectToInstanceButton = new System.Windows.Forms.Button();
            this.RegionSelector = new System.Windows.Forms.ComboBox();
            this.RegionSelectorLabel = new System.Windows.Forms.Label();
            this.InterfaceDeveloperTab = new System.Windows.Forms.TabPage();
            this.FileSystemMaintenanceGroup = new System.Windows.Forms.GroupBox();
            this.DeleteTempFilesButton = new System.Windows.Forms.Button();
            this.PurgeTempFilesWarningLabel = new System.Windows.Forms.Label();
            this.PurgeTemporaryFilesLabel = new System.Windows.Forms.Label();
            this.CloudflareProxyGroup = new System.Windows.Forms.GroupBox();
            this.CloudflareInstallationLocationFinderButton = new System.Windows.Forms.Button();
            this.CloudflareInstallationLocationLabel = new System.Windows.Forms.Label();
            this.CloudflareInstallationLocationInput = new System.Windows.Forms.TextBox();
            this.CloudflareTunnelDescriptionLabel = new System.Windows.Forms.Label();
            this.CloudflareOpenTunnelButton = new System.Windows.Forms.Button();
            this.CloudflarePortLabel = new System.Windows.Forms.Label();
            this.CloudflareDestinationPortInput = new System.Windows.Forms.TextBox();
            this.CloudflareInstallationBrowserDialog = new System.Windows.Forms.OpenFileDialog();
            this.InterfaceTabControl.SuspendLayout();
            this.InterfaceAwsTab.SuspendLayout();
            this.InstanceTypeTab.SuspendLayout();
            this.EC2Tab.SuspendLayout();
            this.RDSTab.SuspendLayout();
            this.InterfaceDeveloperTab.SuspendLayout();
            this.FileSystemMaintenanceGroup.SuspendLayout();
            this.CloudflareProxyGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // InterfaceTabControl
            // 
            this.InterfaceTabControl.Controls.Add(this.InterfaceAwsTab);
            this.InterfaceTabControl.Controls.Add(this.InterfaceDeveloperTab);
            this.InterfaceTabControl.Location = new System.Drawing.Point(12, 12);
            this.InterfaceTabControl.Name = "InterfaceTabControl";
            this.InterfaceTabControl.SelectedIndex = 0;
            this.InterfaceTabControl.Size = new System.Drawing.Size(935, 437);
            this.InterfaceTabControl.TabIndex = 18;
            // 
            // InterfaceAwsTab
            // 
            this.InterfaceAwsTab.Controls.Add(this.InstanceTypeTab);
            this.InterfaceAwsTab.Controls.Add(this.PortForwardToInstanceButton);
            this.InterfaceAwsTab.Controls.Add(this.PortForwardingDocumentHeaderLabel);
            this.InterfaceAwsTab.Controls.Add(this.PortForwardingDocumentDescriptionLabel);
            this.InterfaceAwsTab.Controls.Add(this.PortForwardingDocumentLabel);
            this.InterfaceAwsTab.Controls.Add(this.PortForwardingDocumentInput);
            this.InterfaceAwsTab.Controls.Add(this.OpenAwsConsoleButton);
            this.InterfaceAwsTab.Controls.Add(this.WhatsThisHeaderLabel);
            this.InterfaceAwsTab.Controls.Add(this.OneTimePasswordDescriptionHeaderLabel);
            this.InterfaceAwsTab.Controls.Add(this.OneTimePasswordDescriptionLabel);
            this.InterfaceAwsTab.Controls.Add(this.InstanceListLabel);
            this.InterfaceAwsTab.Controls.Add(this.WhatsThisForLabel);
            this.InterfaceAwsTab.Controls.Add(this.ProfileNameLabel);
            this.InterfaceAwsTab.Controls.Add(this.ProfileNameInput);
            this.InterfaceAwsTab.Controls.Add(this.ProfileNameAdminLabel);
            this.InterfaceAwsTab.Controls.Add(this.ProfileNameAdminInput);
            this.InterfaceAwsTab.Controls.Add(this.OneTimePasswordLabel);
            this.InterfaceAwsTab.Controls.Add(this.OneTimePasswordSecret);
            this.InterfaceAwsTab.Controls.Add(this.RemoteDesktopButton);
            this.InterfaceAwsTab.Controls.Add(this.ConnectToInstanceButton);
            this.InterfaceAwsTab.Controls.Add(this.RegionSelector);
            this.InterfaceAwsTab.Controls.Add(this.RegionSelectorLabel);
            this.InterfaceAwsTab.Location = new System.Drawing.Point(4, 24);
            this.InterfaceAwsTab.Name = "InterfaceAwsTab";
            this.InterfaceAwsTab.Padding = new System.Windows.Forms.Padding(3);
            this.InterfaceAwsTab.Size = new System.Drawing.Size(927, 409);
            this.InterfaceAwsTab.TabIndex = 0;
            this.InterfaceAwsTab.Text = "AWS Infrastructure";
            this.InterfaceAwsTab.UseVisualStyleBackColor = true;
            // 
            // InstanceTypeTab
            // 
            this.InstanceTypeTab.Controls.Add(this.EC2Tab);
            this.InstanceTypeTab.Controls.Add(this.RDSTab);
            this.InstanceTypeTab.Location = new System.Drawing.Point(12, 70);
            this.InstanceTypeTab.Name = "InstanceTypeTab";
            this.InstanceTypeTab.SelectedIndex = 0;
            this.InstanceTypeTab.Size = new System.Drawing.Size(301, 214);
            this.InstanceTypeTab.TabIndex = 39;
            this.InstanceTypeTab.SelectedIndexChanged += new System.EventHandler(this.InstanceTypeTab_SelectedIndexChanged);
            // 
            // EC2Tab
            // 
            this.EC2Tab.Controls.Add(this.InstanceListBox);
            this.EC2Tab.Location = new System.Drawing.Point(4, 24);
            this.EC2Tab.Name = "EC2Tab";
            this.EC2Tab.Padding = new System.Windows.Forms.Padding(3);
            this.EC2Tab.Size = new System.Drawing.Size(293, 186);
            this.EC2Tab.TabIndex = 0;
            this.EC2Tab.Text = "EC2";
            this.EC2Tab.UseVisualStyleBackColor = true;
            // 
            // InstanceListBox
            // 
            this.InstanceListBox.FormattingEnabled = true;
            this.InstanceListBox.ItemHeight = 15;
            this.InstanceListBox.Location = new System.Drawing.Point(0, 0);
            this.InstanceListBox.Name = "InstanceListBox";
            this.InstanceListBox.Size = new System.Drawing.Size(290, 184);
            this.InstanceListBox.TabIndex = 6;
            this.InstanceListBox.SelectedValueChanged += new System.EventHandler(this.InstanceListBox_SelectedValueChanged);
            // 
            // RDSTab
            // 
            this.RDSTab.Controls.Add(this.RDSInstanceListBox);
            this.RDSTab.Location = new System.Drawing.Point(4, 24);
            this.RDSTab.Name = "RDSTab";
            this.RDSTab.Padding = new System.Windows.Forms.Padding(3);
            this.RDSTab.Size = new System.Drawing.Size(293, 186);
            this.RDSTab.TabIndex = 1;
            this.RDSTab.Text = "RDS";
            this.RDSTab.UseVisualStyleBackColor = true;
            // 
            // RDSInstanceListBox
            // 
            this.RDSInstanceListBox.FormattingEnabled = true;
            this.RDSInstanceListBox.ItemHeight = 15;
            this.RDSInstanceListBox.Location = new System.Drawing.Point(1, 1);
            this.RDSInstanceListBox.Name = "RDSInstanceListBox";
            this.RDSInstanceListBox.Size = new System.Drawing.Size(290, 184);
            this.RDSInstanceListBox.TabIndex = 7;
            this.RDSInstanceListBox.SelectedValueChanged += new System.EventHandler(this.RDSInstanceListBox_SelectedValueChanged);
            // 
            // PortForwardToInstanceButton
            // 
            this.PortForwardToInstanceButton.Enabled = false;
            this.PortForwardToInstanceButton.Location = new System.Drawing.Point(12, 319);
            this.PortForwardToInstanceButton.Name = "PortForwardToInstanceButton";
            this.PortForwardToInstanceButton.Size = new System.Drawing.Size(301, 23);
            this.PortForwardToInstanceButton.TabIndex = 38;
            this.PortForwardToInstanceButton.Text = "Open HTTPS Port Forwarding to Instance";
            this.PortForwardToInstanceButton.UseVisualStyleBackColor = true;
            this.PortForwardToInstanceButton.Click += new System.EventHandler(this.PortForwardToInstanceButton_Click);
            // 
            // PortForwardingDocumentHeaderLabel
            // 
            this.PortForwardingDocumentHeaderLabel.AutoSize = true;
            this.PortForwardingDocumentHeaderLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PortForwardingDocumentHeaderLabel.Location = new System.Drawing.Point(565, 169);
            this.PortForwardingDocumentHeaderLabel.Name = "PortForwardingDocumentHeaderLabel";
            this.PortForwardingDocumentHeaderLabel.Size = new System.Drawing.Size(93, 15);
            this.PortForwardingDocumentHeaderLabel.TabIndex = 37;
            this.PortForwardingDocumentHeaderLabel.Text = "What\'s this for?";
            // 
            // PortForwardingDocumentDescriptionLabel
            // 
            this.PortForwardingDocumentDescriptionLabel.Location = new System.Drawing.Point(565, 169);
            this.PortForwardingDocumentDescriptionLabel.Name = "PortForwardingDocumentDescriptionLabel";
            this.PortForwardingDocumentDescriptionLabel.Size = new System.Drawing.Size(356, 64);
            this.PortForwardingDocumentDescriptionLabel.TabIndex = 36;
            this.PortForwardingDocumentDescriptionLabel.Text = resources.GetString("PortForwardingDocumentDescriptionLabel.Text");
            // 
            // PortForwardingDocumentLabel
            // 
            this.PortForwardingDocumentLabel.AutoSize = true;
            this.PortForwardingDocumentLabel.Location = new System.Drawing.Point(408, 143);
            this.PortForwardingDocumentLabel.Name = "PortForwardingDocumentLabel";
            this.PortForwardingDocumentLabel.Size = new System.Drawing.Size(151, 15);
            this.PortForwardingDocumentLabel.TabIndex = 35;
            this.PortForwardingDocumentLabel.Text = "Port Forwarding Document";
            // 
            // PortForwardingDocumentInput
            // 
            this.PortForwardingDocumentInput.Location = new System.Drawing.Point(565, 140);
            this.PortForwardingDocumentInput.Name = "PortForwardingDocumentInput";
            this.PortForwardingDocumentInput.PlaceholderText = "AWS-StartPortForwardingSession";
            this.PortForwardingDocumentInput.Size = new System.Drawing.Size(356, 23);
            this.PortForwardingDocumentInput.TabIndex = 34;
            this.PortForwardingDocumentInput.TextChanged += new System.EventHandler(this.PortForwardingDocumentInput_TextChanged);
            // 
            // OpenAwsConsoleButton
            // 
            this.OpenAwsConsoleButton.Location = new System.Drawing.Point(12, 377);
            this.OpenAwsConsoleButton.Name = "OpenAwsConsoleButton";
            this.OpenAwsConsoleButton.Size = new System.Drawing.Size(301, 23);
            this.OpenAwsConsoleButton.TabIndex = 8;
            this.OpenAwsConsoleButton.Text = "Open AWS Console";
            this.OpenAwsConsoleButton.UseVisualStyleBackColor = true;
            this.OpenAwsConsoleButton.Click += new System.EventHandler(this.OpenAwsConsoleButton_Click);
            // 
            // WhatsThisHeaderLabel
            // 
            this.WhatsThisHeaderLabel.AutoSize = true;
            this.WhatsThisHeaderLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.WhatsThisHeaderLabel.Location = new System.Drawing.Point(565, 70);
            this.WhatsThisHeaderLabel.Name = "WhatsThisHeaderLabel";
            this.WhatsThisHeaderLabel.Size = new System.Drawing.Size(93, 15);
            this.WhatsThisHeaderLabel.TabIndex = 33;
            this.WhatsThisHeaderLabel.Text = "What\'s this for?";
            // 
            // OneTimePasswordDescriptionHeaderLabel
            // 
            this.OneTimePasswordDescriptionHeaderLabel.AutoSize = true;
            this.OneTimePasswordDescriptionHeaderLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OneTimePasswordDescriptionHeaderLabel.Location = new System.Drawing.Point(565, 279);
            this.OneTimePasswordDescriptionHeaderLabel.Name = "OneTimePasswordDescriptionHeaderLabel";
            this.OneTimePasswordDescriptionHeaderLabel.Size = new System.Drawing.Size(93, 15);
            this.OneTimePasswordDescriptionHeaderLabel.TabIndex = 32;
            this.OneTimePasswordDescriptionHeaderLabel.Text = "What\'s this for?";
            // 
            // OneTimePasswordDescriptionLabel
            // 
            this.OneTimePasswordDescriptionLabel.Location = new System.Drawing.Point(565, 279);
            this.OneTimePasswordDescriptionLabel.Name = "OneTimePasswordDescriptionLabel";
            this.OneTimePasswordDescriptionLabel.Size = new System.Drawing.Size(356, 91);
            this.OneTimePasswordDescriptionLabel.TabIndex = 31;
            this.OneTimePasswordDescriptionLabel.Text = resources.GetString("OneTimePasswordDescriptionLabel.Text");
            // 
            // InstanceListLabel
            // 
            this.InstanceListLabel.AutoSize = true;
            this.InstanceListLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InstanceListLabel.Location = new System.Drawing.Point(12, 52);
            this.InstanceListLabel.Name = "InstanceListLabel";
            this.InstanceListLabel.Size = new System.Drawing.Size(87, 15);
            this.InstanceListLabel.TabIndex = 30;
            this.InstanceListLabel.Text = "Your Instances";
            // 
            // WhatsThisForLabel
            // 
            this.WhatsThisForLabel.Location = new System.Drawing.Point(565, 70);
            this.WhatsThisForLabel.Name = "WhatsThisForLabel";
            this.WhatsThisForLabel.Size = new System.Drawing.Size(356, 64);
            this.WhatsThisForLabel.TabIndex = 29;
            this.WhatsThisForLabel.Text = resources.GetString("WhatsThisForLabel.Text");
            // 
            // ProfileNameLabel
            // 
            this.ProfileNameLabel.AutoSize = true;
            this.ProfileNameLabel.Location = new System.Drawing.Point(483, 12);
            this.ProfileNameLabel.Name = "ProfileNameLabel";
            this.ProfileNameLabel.Size = new System.Drawing.Size(76, 15);
            this.ProfileNameLabel.TabIndex = 28;
            this.ProfileNameLabel.Text = "Profile Name";
            // 
            // ProfileNameInput
            // 
            this.ProfileNameInput.Location = new System.Drawing.Point(565, 12);
            this.ProfileNameInput.Name = "ProfileNameInput";
            this.ProfileNameInput.Size = new System.Drawing.Size(356, 23);
            this.ProfileNameInput.TabIndex = 2;
            this.ProfileNameInput.TextChanged += new System.EventHandler(this.ProfileNameInput_TextChanged);
            // 
            // ProfileNameAdminLabel
            // 
            this.ProfileNameAdminLabel.AutoSize = true;
            this.ProfileNameAdminLabel.Location = new System.Drawing.Point(436, 44);
            this.ProfileNameAdminLabel.Name = "ProfileNameAdminLabel";
            this.ProfileNameAdminLabel.Size = new System.Drawing.Size(123, 15);
            this.ProfileNameAdminLabel.TabIndex = 26;
            this.ProfileNameAdminLabel.Text = "Profile Name - Admin";
            // 
            // ProfileNameAdminInput
            // 
            this.ProfileNameAdminInput.Location = new System.Drawing.Point(565, 41);
            this.ProfileNameAdminInput.Name = "ProfileNameAdminInput";
            this.ProfileNameAdminInput.Size = new System.Drawing.Size(356, 23);
            this.ProfileNameAdminInput.TabIndex = 3;
            this.ProfileNameAdminInput.TextChanged += new System.EventHandler(this.ProfileNameAdminInput_TextChanged);
            // 
            // OneTimePasswordLabel
            // 
            this.OneTimePasswordLabel.AutoSize = true;
            this.OneTimePasswordLabel.Location = new System.Drawing.Point(413, 261);
            this.OneTimePasswordLabel.Name = "OneTimePasswordLabel";
            this.OneTimePasswordLabel.Size = new System.Drawing.Size(146, 15);
            this.OneTimePasswordLabel.TabIndex = 24;
            this.OneTimePasswordLabel.Text = "One Time Password Secret";
            // 
            // OneTimePasswordSecret
            // 
            this.OneTimePasswordSecret.Location = new System.Drawing.Point(565, 253);
            this.OneTimePasswordSecret.Name = "OneTimePasswordSecret";
            this.OneTimePasswordSecret.PasswordChar = '*';
            this.OneTimePasswordSecret.Size = new System.Drawing.Size(356, 23);
            this.OneTimePasswordSecret.TabIndex = 4;
            this.OneTimePasswordSecret.TextChanged += new System.EventHandler(this.OneTimePasswordSecret_TextChanged);
            // 
            // RemoteDesktopButton
            // 
            this.RemoteDesktopButton.Enabled = false;
            this.RemoteDesktopButton.Location = new System.Drawing.Point(12, 348);
            this.RemoteDesktopButton.Name = "RemoteDesktopButton";
            this.RemoteDesktopButton.Size = new System.Drawing.Size(301, 23);
            this.RemoteDesktopButton.TabIndex = 7;
            this.RemoteDesktopButton.Text = "Open Remote Desktop";
            this.RemoteDesktopButton.UseVisualStyleBackColor = true;
            this.RemoteDesktopButton.Click += new System.EventHandler(this.RemoteDesktopButton_Click);
            // 
            // ConnectToInstanceButton
            // 
            this.ConnectToInstanceButton.Enabled = false;
            this.ConnectToInstanceButton.Location = new System.Drawing.Point(12, 290);
            this.ConnectToInstanceButton.Name = "ConnectToInstanceButton";
            this.ConnectToInstanceButton.Size = new System.Drawing.Size(301, 23);
            this.ConnectToInstanceButton.TabIndex = 6;
            this.ConnectToInstanceButton.Text = "Open Tunnel to Instance";
            this.ConnectToInstanceButton.UseVisualStyleBackColor = true;
            this.ConnectToInstanceButton.Click += new System.EventHandler(this.ConnectToInstanceButton_Click);
            // 
            // RegionSelector
            // 
            this.RegionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RegionSelector.FormattingEnabled = true;
            this.RegionSelector.Items.AddRange(new object[] {
            "us-east-1",
            "us-east-2"});
            this.RegionSelector.Location = new System.Drawing.Point(62, 9);
            this.RegionSelector.Name = "RegionSelector";
            this.RegionSelector.Size = new System.Drawing.Size(251, 23);
            this.RegionSelector.TabIndex = 1;
            this.RegionSelector.SelectedValueChanged += new System.EventHandler(this.RegionSelector_SelectedValueChanged);
            // 
            // RegionSelectorLabel
            // 
            this.RegionSelectorLabel.AutoSize = true;
            this.RegionSelectorLabel.Location = new System.Drawing.Point(12, 12);
            this.RegionSelectorLabel.Name = "RegionSelectorLabel";
            this.RegionSelectorLabel.Size = new System.Drawing.Size(44, 15);
            this.RegionSelectorLabel.TabIndex = 18;
            this.RegionSelectorLabel.Text = "Region";
            // 
            // InterfaceDeveloperTab
            // 
            this.InterfaceDeveloperTab.Controls.Add(this.FileSystemMaintenanceGroup);
            this.InterfaceDeveloperTab.Controls.Add(this.CloudflareProxyGroup);
            this.InterfaceDeveloperTab.Location = new System.Drawing.Point(4, 24);
            this.InterfaceDeveloperTab.Name = "InterfaceDeveloperTab";
            this.InterfaceDeveloperTab.Padding = new System.Windows.Forms.Padding(3);
            this.InterfaceDeveloperTab.Size = new System.Drawing.Size(927, 409);
            this.InterfaceDeveloperTab.TabIndex = 1;
            this.InterfaceDeveloperTab.Text = "Developer Tools";
            this.InterfaceDeveloperTab.UseVisualStyleBackColor = true;
            // 
            // FileSystemMaintenanceGroup
            // 
            this.FileSystemMaintenanceGroup.Controls.Add(this.DeleteTempFilesButton);
            this.FileSystemMaintenanceGroup.Controls.Add(this.PurgeTempFilesWarningLabel);
            this.FileSystemMaintenanceGroup.Controls.Add(this.PurgeTemporaryFilesLabel);
            this.FileSystemMaintenanceGroup.Location = new System.Drawing.Point(6, 161);
            this.FileSystemMaintenanceGroup.Name = "FileSystemMaintenanceGroup";
            this.FileSystemMaintenanceGroup.Size = new System.Drawing.Size(915, 102);
            this.FileSystemMaintenanceGroup.TabIndex = 1;
            this.FileSystemMaintenanceGroup.TabStop = false;
            this.FileSystemMaintenanceGroup.Text = "File System Maintenance";
            // 
            // DeleteTempFilesButton
            // 
            this.DeleteTempFilesButton.BackColor = System.Drawing.Color.Red;
            this.DeleteTempFilesButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.DeleteTempFilesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteTempFilesButton.ForeColor = System.Drawing.Color.White;
            this.DeleteTempFilesButton.Location = new System.Drawing.Point(648, 34);
            this.DeleteTempFilesButton.Name = "DeleteTempFilesButton";
            this.DeleteTempFilesButton.Size = new System.Drawing.Size(261, 53);
            this.DeleteTempFilesButton.TabIndex = 2;
            this.DeleteTempFilesButton.Text = "Delete Temporary ASP.NET Files";
            this.DeleteTempFilesButton.UseVisualStyleBackColor = false;
            this.DeleteTempFilesButton.Click += new System.EventHandler(this.DeleteTempFilesButton_Click);
            // 
            // PurgeTempFilesWarningLabel
            // 
            this.PurgeTempFilesWarningLabel.ForeColor = System.Drawing.Color.Red;
            this.PurgeTempFilesWarningLabel.Location = new System.Drawing.Point(6, 34);
            this.PurgeTempFilesWarningLabel.Name = "PurgeTempFilesWarningLabel";
            this.PurgeTempFilesWarningLabel.Size = new System.Drawing.Size(493, 53);
            this.PurgeTempFilesWarningLabel.TabIndex = 1;
            this.PurgeTempFilesWarningLabel.Text = resources.GetString("PurgeTempFilesWarningLabel.Text");
            // 
            // PurgeTemporaryFilesLabel
            // 
            this.PurgeTemporaryFilesLabel.AutoSize = true;
            this.PurgeTemporaryFilesLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PurgeTemporaryFilesLabel.Location = new System.Drawing.Point(6, 19);
            this.PurgeTemporaryFilesLabel.Name = "PurgeTemporaryFilesLabel";
            this.PurgeTemporaryFilesLabel.Size = new System.Drawing.Size(178, 15);
            this.PurgeTemporaryFilesLabel.TabIndex = 0;
            this.PurgeTemporaryFilesLabel.Text = "Purge Temporary ASP.NET Files";
            // 
            // CloudflareProxyGroup
            // 
            this.CloudflareProxyGroup.Controls.Add(this.CloudflareInstallationLocationFinderButton);
            this.CloudflareProxyGroup.Controls.Add(this.CloudflareInstallationLocationLabel);
            this.CloudflareProxyGroup.Controls.Add(this.CloudflareInstallationLocationInput);
            this.CloudflareProxyGroup.Controls.Add(this.CloudflareTunnelDescriptionLabel);
            this.CloudflareProxyGroup.Controls.Add(this.CloudflareOpenTunnelButton);
            this.CloudflareProxyGroup.Controls.Add(this.CloudflarePortLabel);
            this.CloudflareProxyGroup.Controls.Add(this.CloudflareDestinationPortInput);
            this.CloudflareProxyGroup.Location = new System.Drawing.Point(6, 6);
            this.CloudflareProxyGroup.Name = "CloudflareProxyGroup";
            this.CloudflareProxyGroup.Size = new System.Drawing.Size(915, 149);
            this.CloudflareProxyGroup.TabIndex = 0;
            this.CloudflareProxyGroup.TabStop = false;
            this.CloudflareProxyGroup.Text = "Cloudflare Tunnel";
            // 
            // CloudflareInstallationLocationFinderButton
            // 
            this.CloudflareInstallationLocationFinderButton.Location = new System.Drawing.Point(732, 110);
            this.CloudflareInstallationLocationFinderButton.Name = "CloudflareInstallationLocationFinderButton";
            this.CloudflareInstallationLocationFinderButton.Size = new System.Drawing.Size(177, 23);
            this.CloudflareInstallationLocationFinderButton.TabIndex = 6;
            this.CloudflareInstallationLocationFinderButton.Text = "Browse...";
            this.CloudflareInstallationLocationFinderButton.UseVisualStyleBackColor = true;
            this.CloudflareInstallationLocationFinderButton.Click += new System.EventHandler(this.CloudflareInstallationLocationFinderButton_Click);
            // 
            // CloudflareInstallationLocationLabel
            // 
            this.CloudflareInstallationLocationLabel.AutoSize = true;
            this.CloudflareInstallationLocationLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CloudflareInstallationLocationLabel.Location = new System.Drawing.Point(6, 113);
            this.CloudflareInstallationLocationLabel.Name = "CloudflareInstallationLocationLabel";
            this.CloudflareInstallationLocationLabel.Size = new System.Drawing.Size(147, 15);
            this.CloudflareInstallationLocationLabel.TabIndex = 5;
            this.CloudflareInstallationLocationLabel.Text = "Cloudflared Tool Location";
            // 
            // CloudflareInstallationLocationInput
            // 
            this.CloudflareInstallationLocationInput.Location = new System.Drawing.Point(159, 110);
            this.CloudflareInstallationLocationInput.Name = "CloudflareInstallationLocationInput";
            this.CloudflareInstallationLocationInput.Size = new System.Drawing.Size(567, 23);
            this.CloudflareInstallationLocationInput.TabIndex = 4;
            // 
            // CloudflareTunnelDescriptionLabel
            // 
            this.CloudflareTunnelDescriptionLabel.Location = new System.Drawing.Point(6, 19);
            this.CloudflareTunnelDescriptionLabel.Name = "CloudflareTunnelDescriptionLabel";
            this.CloudflareTunnelDescriptionLabel.Size = new System.Drawing.Size(782, 55);
            this.CloudflareTunnelDescriptionLabel.TabIndex = 3;
            this.CloudflareTunnelDescriptionLabel.Text = resources.GetString("CloudflareTunnelDescriptionLabel.Text");
            // 
            // CloudflareOpenTunnelButton
            // 
            this.CloudflareOpenTunnelButton.Location = new System.Drawing.Point(732, 76);
            this.CloudflareOpenTunnelButton.Name = "CloudflareOpenTunnelButton";
            this.CloudflareOpenTunnelButton.Size = new System.Drawing.Size(177, 23);
            this.CloudflareOpenTunnelButton.TabIndex = 2;
            this.CloudflareOpenTunnelButton.Text = "Create Tunnel";
            this.CloudflareOpenTunnelButton.UseVisualStyleBackColor = true;
            this.CloudflareOpenTunnelButton.Click += new System.EventHandler(this.CloudflareOpenTunnelButton_Click);
            // 
            // CloudflarePortLabel
            // 
            this.CloudflarePortLabel.AutoSize = true;
            this.CloudflarePortLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CloudflarePortLabel.Location = new System.Drawing.Point(6, 80);
            this.CloudflarePortLabel.Name = "CloudflarePortLabel";
            this.CloudflarePortLabel.Size = new System.Drawing.Size(98, 15);
            this.CloudflarePortLabel.TabIndex = 1;
            this.CloudflarePortLabel.Text = "Destination Port";
            // 
            // CloudflareDestinationPortInput
            // 
            this.CloudflareDestinationPortInput.Location = new System.Drawing.Point(159, 77);
            this.CloudflareDestinationPortInput.Name = "CloudflareDestinationPortInput";
            this.CloudflareDestinationPortInput.PlaceholderText = "44300";
            this.CloudflareDestinationPortInput.Size = new System.Drawing.Size(567, 23);
            this.CloudflareDestinationPortInput.TabIndex = 0;
            // 
            // CloudflareInstallationBrowserDialog
            // 
            this.CloudflareInstallationBrowserDialog.FileName = "cloudflared.exe";
            this.CloudflareInstallationBrowserDialog.Filter = "cloudflared executable|cloudflared.exe";
            this.CloudflareInstallationBrowserDialog.InitialDirectory = "c:\\";
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 456);
            this.Controls.Add(this.InterfaceTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Interface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AW(yes)";
            this.InterfaceTabControl.ResumeLayout(false);
            this.InterfaceAwsTab.ResumeLayout(false);
            this.InterfaceAwsTab.PerformLayout();
            this.InstanceTypeTab.ResumeLayout(false);
            this.EC2Tab.ResumeLayout(false);
            this.RDSTab.ResumeLayout(false);
            this.InterfaceDeveloperTab.ResumeLayout(false);
            this.FileSystemMaintenanceGroup.ResumeLayout(false);
            this.FileSystemMaintenanceGroup.PerformLayout();
            this.CloudflareProxyGroup.ResumeLayout(false);
            this.CloudflareProxyGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl InterfaceTabControl;
        private TabPage InterfaceAwsTab;
        private TabPage InterfaceDeveloperTab;
        private Button OpenAwsConsoleButton;
        private Label WhatsThisHeaderLabel;
        private Label OneTimePasswordDescriptionHeaderLabel;
        private Label OneTimePasswordDescriptionLabel;
        private Label InstanceListLabel;
        private Label WhatsThisForLabel;
        private Label ProfileNameLabel;
        private TextBox ProfileNameInput;
        private Label ProfileNameAdminLabel;
        private TextBox ProfileNameAdminInput;
        private Label OneTimePasswordLabel;
        private TextBox OneTimePasswordSecret;
        private Button RemoteDesktopButton;
        private Button ConnectToInstanceButton;
        private ComboBox RegionSelector;
        private Label RegionSelectorLabel;
        private GroupBox CloudflareProxyGroup;
        private TextBox CloudflareDestinationPortInput;
        private Label CloudflarePortLabel;
        private Button CloudflareOpenTunnelButton;
        private Label CloudflareTunnelDescriptionLabel;
        private Button CloudflareInstallationLocationFinderButton;
        private Label CloudflareInstallationLocationLabel;
        private TextBox CloudflareInstallationLocationInput;
        private OpenFileDialog CloudflareInstallationBrowserDialog;
        private GroupBox FileSystemMaintenanceGroup;
        private Label PurgeTemporaryFilesLabel;
        private Label PurgeTempFilesWarningLabel;
        private Button DeleteTempFilesButton;
        private Label PortForwardingDocumentHeaderLabel;
        private Label PortForwardingDocumentDescriptionLabel;
        private Label PortForwardingDocumentLabel;
        private TextBox PortForwardingDocumentInput;
        private Button PortForwardToInstanceButton;
        private TabControl InstanceTypeTab;
        private TabPage EC2Tab;
        private ListBox InstanceListBox;
        private TabPage RDSTab;
        private ListBox RDSInstanceListBox;
    }
}