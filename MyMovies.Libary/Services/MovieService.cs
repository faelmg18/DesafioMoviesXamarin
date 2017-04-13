using MyMovies.Libary.Infrastructure;
using MyMovies.Libary.Model.Fundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Libary.Services
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
