using MoviesApi.Libary.Infrastructure;
using MoviesApi.Libary.Model.Fundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Libary.Services
{
    public class MovieService
    {
        public const string FindMoviesAddress = "?t={0}";

        private IHttpClientProvider _httpClient;

        public MovieService(IHttpClientProvider httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Movie> FindMovie(string movieTitle)
        {
            return await _httpClient.Get<Movie>(string.Format(FindMoviesAddress, movieTitle));
        }
    }
}
