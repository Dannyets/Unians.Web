using Microsoft.AspNetCore.Http;

namespace Unians.Web.Api.Data.Models
{
    public class MultipartFormDataRequest
    {
        public string Body { get; set; }

        public IFormFile File { get; set; }
    }
}
