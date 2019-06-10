using Amazon;
using Amazon.Runtime;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Unians.Web.Amazon.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAwsCredentials(this IServiceCollection services)
        {
            var accessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY");
            var secretKey = Environment.GetEnvironmentVariable("AWS_SECRET_KEY");

            var region = RegionEndpoint.USEast2;

            var credentials = new BasicAWSCredentials(accessKey, secretKey);

            var amazonConfig = new AmazonConfig(credentials, region);

            services.AddSingleton(amazonConfig);
        }
    }
}
