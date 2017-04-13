using System;
using System.Collections.Generic;
using MyMovies.Libary.Infrastructure;
using MyMovies.Libary.Services;
using MyMovies.Persistence;
using MyMovies.Libary.Persistence;

namespace MyMovies.Services
{
    public class Container : IContainer
    {
        private readonly Dictionary<Type, object> _container = new Dictionary<Type, object>();

        public Container()
        {
            try
            {
                var httpClientProvider = new HttpClientProvider();
                var movieService = new MovieService(httpClientProvider);
                var movieRepository = RepositoryFactory.CreateMoviesRepository();


                _container.Add(typeof(IHttpClientProvider), httpClientProvider);
                _container.Add(typeof(MovieService), movieService);
                _container.Add(typeof(MovieRepository), movieRepository);

            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public T Resolve<T>() where T : class
        {
            object resolve;
            _container.TryGetValue(typeof(T), out resolve);
            return resolve as T;
        }
    }
}