using Android.App;
using Android.OS;
using MyMovies.Libary.Model.Fundation;
using MyMovies.Libary.Persistence;
using MyMovies.OmdbApi;
using MyMovies.Persistence;
using MyMovies.Utils;

namespace MyMovies
{
    [Activity(Label = "MyMovies", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //var movieRepository = this.Resolve<MovieRepository>();

            //OmdbApiMovies omdbApiMovies = new OmdbApiMovies(this);
            //omdbApiMovies.FindMovie("Ice", (movie) =>
            //{
            //    if (movie.ID > 0)
            //    {
            //        return;
            //    }
            //    movieRepository.SaveOrUpdate(movie);
            //});

        }
    }
}

