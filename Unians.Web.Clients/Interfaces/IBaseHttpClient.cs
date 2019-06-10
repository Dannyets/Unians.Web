using System.Threading.Tasks;

namespace Unians.Web.Interfaces
{
    public interface IBaseHttpClient
    {
        Task<T> Post<T>(string controllerName, string actionName, string queryString = null, object body = null);

        Task Post(string controllerName, string actionName, string queryString = null, object body = null);

        Task Put(string controllerName, string actionName, string queryString = null, object body = null);
    }
}
