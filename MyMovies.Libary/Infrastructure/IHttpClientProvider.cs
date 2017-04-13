using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Libary.Infrastructure
{
    public interface IHttpClientProvider
    {

        Task<T> Post<T>(string url, object content = null);
        Task<T> Put<T>(string url, object content = null);
        Task<T> Get<T>(string url, object content = null);
        Task Delete(string url);
    }
}
