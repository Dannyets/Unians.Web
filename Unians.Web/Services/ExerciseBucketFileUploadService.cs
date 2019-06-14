using De.Amazon.Configuration.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unians.Web.Services
{
    public class ExerciseBucketFileUploadService : BaseS3BucketFileUploadService
    {
        public ExerciseBucketFileUploadService(AmazonConfiguration amazonConfig, 
                                               IConfiguration configuration) : base(amazonConfig, configuration)
        {

        }

        protected override string GetBucketName() => _configuration["Exercise:ImageBucket"];
    }
}
