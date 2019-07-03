using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Unians.Web.Clients.Enums;
using Unians.Web.Interfaces;

namespace Unians.Web.Clients
{
    public class BaseHttpClient : IBaseHttpClient
    {
        protected string _baseUrl;
        private readonly HttpClient _client;

        public BaseHttpClient(string apiName, 
                              IConfiguration configuration,
                              HttpClient client)
        {
            _baseUrl = configuration[$"Apis:{apiName}:BaseUrl"];
            _client = client;
        }

        public BaseHttpClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> Get<T>(string route, string queryString = null)
        {
            var response = await Request(RequestType.Get, route, queryString);

            return await HandleResponse<T>(response);
        }

        public async Task<T> Post<T>(string route, string queryString = null, object body = null)
        {
            var response = await Request(RequestType.Post, route, queryString, body);

            return await HandleResponse<T>(response);
        }

        public async Task Post(string route, string queryString = null, object body = null)
        {
            var response = await Request(RequestType.Post, route, queryString, body);

            await HandleResponse(response);
        }

        public async Task Put(string route, string queryString = null, object body = null)
        {
            var response = await Request(RequestType.Put, route, queryString, body);

            await HandleResponse(response);
        }

        public async Task Delete(string route, string queryString = null, object body = null)
        {
            var response = await Request(RequestType.Delete, route, queryString, body);

            await HandleResponse(response);
        }


        private async Task<HttpResponseMessage> Request(RequestType requestType, 
                                                        string route, 
                                                        string queryString = null, 
                                                        object body = null)
        {
            var fullUrl = GetFullUrl(route, queryString);

            var jsonBody = SerializeBody(body);

            HttpResponseMessage response = null;

            switch (requestType)
            {
                case RequestType.Get:
                    response = await _client.GetAsync(fullUrl);
                    break;

                case RequestType.Post:
                    response = await _client.PostAsync(fullUrl, jsonBody);
                    break;

                case RequestType.Put:
                    response = await _client.PutAsync(fullUrl, jsonBody);
                    break;

                case RequestType.Delete:
                    response = await _client.DeleteAsync(fullUrl);
                    break;

                default:
                    break;
            }

            return response;
        }

        private StringContent SerializeBody(object body)
        {
            if(body == null)
            {
                return null;
            }

            return new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            T responseContent = default;

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();

                responseContent = JsonConvert.DeserializeObject<T>(responseJson);
            }
            else
            {
                await HandleError(response);
            }

            return responseContent;
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if(response == null)
            {
                throw new Exception("Empty response");
            }

            if (!response.IsSuccessStatusCode)
            {
                await HandleError(response);
            }
        }

        private async Task HandleError(HttpResponseMessage response)
        {
            var reason = await response.Content.ReadAsStringAsync();

            throw new Exception(reason);
        }

        private string GetFullUrl(string route, string queryString)
        {
            var url = $"{_baseUrl}/{route}";

            if (string.IsNullOrEmpty(queryString))
            {
                return url;
            }

            url += $"?{queryString}";

            return url;
        }
    }
}
