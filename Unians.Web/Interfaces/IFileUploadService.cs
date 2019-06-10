using System.IO;
using System.Threading.Tasks;
using Unians.Web.Models;

namespace Unians.Web.Interfaces
{
    public interface IFileUploadService
    {
        Task<bool> UploadFileAsync(string fileName, Stream storageStream);
    }
}
