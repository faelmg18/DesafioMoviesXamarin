using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyMovies.Libary.Model.Fundation;
using MyMovies.Utils;
using MyMovies.Libary.Services;
using MyMovies.Libary.Persistence;
using MyMovies.Persistence;

namespace MyMovies.OmdbApi
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