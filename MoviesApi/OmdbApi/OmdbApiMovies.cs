using System;
using Android.App;
using MoviesApi.Libary.Services;
using MoviesApi.Libary.Persistence;
using MoviesApi.Utils;
using MoviesApi.Libary.Model.Fundation;

namespace MoviesApi.OmdbApi
{
    public class OmdbApiMovies
    {
        public Activity Activity { get; set; }
        public MovieService MovieService { get; set; }
        public Action<Movie> OnFoundMovie { get; set; }
        public MovieRepository MovieRepository { get; set; }
        public OmdbApiMovies(Activity activity)
        {
            Activity = activity;
            MovieService = activity.Resolve<MovieService>();
            MovieRepository = activity.Resolve<MovieRepository>();
        }
        public void FindMovie(string movieTitle, Action<Movie> onFoundMovie)
        {
            OnFoundMovie = onFoundMovie;

            var movies = MovieRepository.RetrieveAllByName(movieTitle);

            if (movies.Count > 0)
            {
                OnSuccess(movies[0]);
                return;
            }

            Activity.ExecuteAsync(MovieService.FindMovie(movieTitle), OnSuccess, OnError);
        }

        private void OnError(Exception ex)
        {
        }

        private void OnSuccess(Movie movie)
        {
            Activity.RunOnUiThread(() =>
            {
                OnFoundMovie?.Invoke(movie);
            });
        }
    }
}