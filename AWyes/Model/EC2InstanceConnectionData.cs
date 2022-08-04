namespace AWyes.Model
{
    public class EC2InstanceConnectionData
    {
        /// <summary>
        /// The local port to open a tunnel on (Windows instances only)
        /// </summary>
        public int LocalPort { get; set; }

        /// <summary>
        /// The local port to open a port-forwarding tunnel on
        /// </summary>
        public int PortForwardingLocalPort { get; set; }

        /// <summary>
        /// The EC2 instance identifier
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// The region the instance sits in
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// The name of the profile to use for AWS Vault
        /// </summary>
        public string ProfileName { get; set; }

        /// <summary>
        /// The multi-factor authentication flag to pass if we have 2FA configured in this app
        /// </summary>
        public string MultiFactorFlag { get; set; }
    }
}
