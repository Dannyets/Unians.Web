using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using System.Net;
using Unians.Web.Interfaces;
using Unians.Web.Amazon;

namespace Unians.Web.Services
{
    public abstract class BaseS3BucketFileUploadService : IFileUploadService
    {
        private readonly AmazonConfig _amazonConfig;
        protected readonly IConfiguration _configuration;

        public BaseS3BucketFileUploadService(AmazonConfig amazonConfig, IConfiguration configuration)
        {
            _amazonConfig = amazonConfig;
            _configuration = configuration;
        }

        public async Task<bool> UploadFileAsync(string fileName, Stream storageStream)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("File name must be specified");
            }

            using(var client = new AmazonS3Client(_amazonConfig.Credentials, _amazonConfig.RegionEndpoint))
            {
                if(storageStream.Length > 0)
                {
                    storageStream.Seek(0, SeekOrigin.Begin);
                }

                var request = new PutObjectRequest
                {
                    AutoCloseStream = true,
                    BucketName = GetBucketName(),
                    InputStream = storageStream,
                    Key = fileName
                };

                var response = await client.PutObjectAsync(request).ConfigureAwait(false);

                return response.HttpStatusCode == HttpStatusCode.OK;
            }
        }

        protected abstract string GetBucketName();
    }
}
