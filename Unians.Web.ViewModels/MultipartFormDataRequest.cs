using Microsoft.AspNetCore.Http;

namespace Unians.Web.ViewModels
{
    public class MultipartFormDataRequest
    {
        public string Body { get; set; }

        public IFormFile File { get; set; }
    }
}
