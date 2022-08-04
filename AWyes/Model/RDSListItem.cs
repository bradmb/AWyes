using Amazon.EC2.Model;
using Amazon.RDS.Model;

namespace AWyes.Model
{
    internal class RDSListItem
    {
        internal RDSListItem(DBInstance instance)
        {
            InstanceData = instance;
        }

        /// <summary>
        /// On active connections, contains the port number in use
        /// </summary>
        public int? ActiveConnectionPortNumber { get; set; }

        /// <summary>
        /// On port forwarding connections, contains the port number in use
        /// </summary>
        public int? PortForwardingConnectionPortNumber { get; set; }

        /// <summary>
        /// Identifies the type of instance
        /// </summary>
        public RDSInstanceType InstanceType
        {
            get
            {
                if (InstanceData.Engine?.Contains("sqlserver") == true)
                {
                    return RDSInstanceType.SQLServer;
                }

                return RDSInstanceType.Unknown;
            }
        }

        /// <summary>
        /// The display name of the instance
        /// </summary>
        public string DisplayName
        {
            get
            {
                return InstanceData.DBName + InstanceData.DBInstanceIdentifier;
            }
        }

        /// <summary>
        /// The data associated with the instance
        /// </summary>
        public DBInstance InstanceData { get; set; }
    }
}