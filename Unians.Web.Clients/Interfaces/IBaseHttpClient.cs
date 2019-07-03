using System.Threading.Tasks;

namespace Unians.Web.Interfaces
{
    public interface IBaseHttpClient
    {
        Task<T> Get<T>(string route, string queryString = null);

        Task<T> Post<T>(string route, string queryString = null, object body = null);

        Task Post(string route, string queryString = null, object body = null);

        Task Put(string route, string queryString = null, object body = null);

        Task Delete(string route, string queryString = null, object body = null);
    }
}
