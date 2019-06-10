using Amazon;
using Amazon.Runtime;

namespace Unians.Web.Amazon
{
    public class AmazonConfig
    {
        public AmazonConfig(AWSCredentials credentials,
                            RegionEndpoint regionEndpoint)
        {
            Credentials = credentials;
            RegionEndpoint = regionEndpoint;
        }

        public AWSCredentials Credentials { get; }

        public RegionEndpoint RegionEndpoint { get; }
    }
}
