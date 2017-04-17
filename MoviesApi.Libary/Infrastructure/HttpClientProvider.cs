using MoviesApi.Libary.Infrastructure;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace MoviesApi.Libary.Infrastructure
{
    public class HttpClientProvider : IHttpClientProvider
    {
        public Task Delete(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get<T>(string url, object content = null)
        {
            try
            {
                var webRequest = CreateWebRequest(url);
                webRequest.Method = "GET";
                var response = await webRequest.GetResponseAsync();
                var receiveStream = response.GetResponseStream();
                using (var reader = new StreamReader(receiveStream))
                {
                    var result = await reader.ReadToEndAsync();
                    return JsonConvert.DeserializeObject<T>(result);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<T> Post<T>(string url, object content = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> Put<T>(string url, object content = null)
        {
            throw new NotImplementedException();
        }

        private WebRequest CreateWebRequest(string url)
        {
            var uri = new Uri(string.Format(AppEnv.Application.ServerAddress, url));
            var webRequest = WebRequest.Create(uri);

            return webRequest;
        }
    }
}
