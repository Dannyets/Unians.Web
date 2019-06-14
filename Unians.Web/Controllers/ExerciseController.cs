using BaseRepositories.Models;
using BaseRepositories.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using Unians.Web.Interfaces;
using Unians.Web.Models;
using Unians.Web.Services;
using Unians.Web.ViewModels;
using Unians.Web.ViewModels.Exercise;

namespace Unians.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ExerciseController : ControllerBase
    {
        private IFileUploadService _fileUploader;
        private IExerciseApiClient _exerciseApiClient;
        private IConfiguration _configuration;

        public ExerciseController(ExerciseBucketFileUploadService fileUploader,
                                  IExerciseApiClient exerciseApiClient,
                                  IConfiguration configuration)
        {
            _fileUploader = fileUploader;
            _exerciseApiClient = exerciseApiClient;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<CreateExerciseViewModel>> Create([FromForm] MultipartFormDataRequest requestData)
        {
            var model = JsonConvert.DeserializeObject<CreateExerciseViewModel>(requestData.Body);

            var failedFileUploadStatusCode = StatusCode(500, "Failed to upload image");

            UploadFileResponse uploadFileResponse;

            try
            {
                uploadFileResponse = await UploadFormFile(requestData.File);

                if (!uploadFileResponse.IsSucceeded)
                {
                    return failedFileUploadStatusCode;
                }
            }
            catch (Exception)
            {
                return failedFileUploadStatusCode;
            }


            var failedDbTransactionStatusCode = StatusCode(500, "Falied to add exercise to databse");
            
            try
            {
                model = await _exerciseApiClient.CreateExercise(model);

                if(model == null)
                {
                    return failedDbTransactionStatusCode;
                }
            }
            catch (Exception ex)
            {
                return failedDbTransactionStatusCode;
            }

            var cloudFrontDomain = _configuration["Exercise:CloudFrontDomain"];

            model.FilePath = Path.Combine(cloudFrontDomain, uploadFileResponse.FilePath);

            return StatusCode(200, model);
        }

        private async Task<UploadFileResponse> UploadFormFile(IFormFile file)
        {
            var imageId = new Guid().ToString();

            var fileName = String.IsNullOrEmpty(file.FileName)
                ? imageId
                : Path.GetFileName(file.FileName);

            var filePath = $"{imageId}/{fileName}";

            var uploadFileResponse = new UploadFileResponse
            {
                FilePath = filePath
            };

            using (var readStream = file.OpenReadStream())
            {
                uploadFileResponse.IsSucceeded = await _fileUploader.UploadFileAsync(filePath, readStream);
            }

            return uploadFileResponse;
        }
    }
}
