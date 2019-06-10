using BaseRepositories.Models;
using BaseRepositories.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ExerciseController(ExerciseBucketFileUploadService fileUploader,
                                  IExerciseApiClient exerciseApiClient)
        {
            _fileUploader = fileUploader;
            _exerciseApiClient = exerciseApiClient;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] MultipartFormDataRequest requestData)
        {
            var model = JsonConvert.DeserializeObject<CreateExerciseViewModel>(requestData.Body);

            var failedFileUploadStatusCode = StatusCode(500, "Failed to upload image");

            try
            {
                var uploadResponse = await UploadFormFile(requestData.File);

                if (!uploadResponse.IsSucceeded)
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
                var id = await _exerciseApiClient.CreateExercise(model);

                if(id == null)
                {
                    return failedDbTransactionStatusCode;
                }
            }
            catch (Exception)
            {
                return failedDbTransactionStatusCode;
            }

            return StatusCode(200, "Exercise created successfully");
;
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
