using Amazon.ServiceDiscovery;
using Amazon.ServiceDiscovery.Model;
using De.Amazon.Configuration.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Unians.Web.Clients.Enums;
using Unians.Web.Interfaces;

namespace Unians.Web.Clients
{
    public class BaseAmazonDiscoveryHttpClient : BaseHttpClient
    {
        public BaseAmazonDiscoveryHttpClient(string serviceNamespace,
                                             string serviceName,
                                             AmazonConfiguration amazonConfiguration,
                                             HttpClient client) : base(client)
        {
            var discoverClient = new AmazonServiceDiscoveryClient(amazonConfiguration.Credentials,
                                                                  amazonConfiguration.RegionEndpoint);

            var discoverInstanceRequest = new DiscoverInstancesRequest
            {
                ServiceName = serviceName,
                NamespaceName = serviceNamespace,
                HealthStatus = HealthStatus.HEALTHY.Value
            };

            var discoveryTask = discoverClient.DiscoverInstancesAsync(discoverInstanceRequest);

            discoveryTask.Wait();

            var instances = discoveryTask.Result.Instances;

            var instance = instances.FirstOrDefault();

            var ipv4 = instance.Attributes["AWS_INSTANCE_IPV4"];
            var port = instance.Attributes["AWS_INSTANCE_PORT"];

            _baseUrl = $"http://{ipv4}:{port}";
        }
    }
}
