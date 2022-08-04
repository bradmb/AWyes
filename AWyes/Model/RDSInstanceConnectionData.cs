namespace AWyes.Model
{
    public class RDSInstanceConnectionData
    {
        /// <summary>
        /// The port to access on the remote server
        /// </summary>
        public int ServerPort { get; set; }

        /// <summary>
        /// The local port to open a port-forwarding tunnel on
        /// </summary>
        public int LocalPort { get; set; }

        /// <summary>
        /// The instance identifier of the server we will tunnel through
        /// </summary>
        public string TunnelInstanceId { get; set; }

        /// <summary>
        /// The RDS instance endpoint address
        /// </summary>
        public string EndpointAddress { get; set; }

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
