using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Unians.Web.Interfaces
{
    public interface IFormService
    {
        Stream ReadFile(IFormFile imageFile);
    }
}
