using Amazon.EC2.Model;

namespace AWyes.Model
{
    internal class EC2ListItem
    {
        internal EC2ListItem(Instance instance)
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
        public EC2InstanceType InstanceType
        {
            get
            {
                var instanceType = InstanceData.Platform?.Value ?? InstanceData.PlatformDetails;
                switch (instanceType)
                {
                    case "Windows":
                        return EC2InstanceType.Windows;

                    case "Linux/UNIX":
                        return EC2InstanceType.Linux;

                    default:
                        return EC2InstanceType.Unknown;
                }
            }
        }

        /// <summary>
        /// The display name of the instance
        /// </summary>
        public string DisplayName
        {
            get
            {
                var nameTag = InstanceData.Tags.FirstOrDefault(t => t.Key == "Name");
                var instanceName = nameTag != null ? $"{nameTag.Value} - " : string.Empty;
                var tags = InstanceData.Tags.Where(t => t.Key != "Name");
                var tagList = string.Empty;

                if (tags.Any())
                {
                    tagList = $" - {string.Join(", ", tags.Select(t => t.Value))}";
                }

                return instanceName + InstanceData.InstanceId + tagList;
            }
        }

        /// <summary>
        /// The data associated with the instance
        /// </summary>
        public Instance InstanceData { get; set; }
    }
}