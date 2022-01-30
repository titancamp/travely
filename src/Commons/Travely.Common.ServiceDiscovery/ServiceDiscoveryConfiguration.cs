using System;

namespace Travely.Common.ServiceDiscovery
{
    public class ServiceDiscoveryConfiguration
    {
        public Uri ServiceAddress { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
    }
}
