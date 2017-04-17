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
using Android.Support.Design.Widget;
using MoviesApi.Libary.Model.Fundation;
using MoviesApi.UI.Components;

namespace MoviesApi.UI.Screens.Activities
{
    [Activity(Label = "MyMovies", Theme = "@style/CustomActionBarTheme")]
    public class MovieDetail : BaseActivity
    {
        private TextView textViewTitleMovie;
        private TextView textViewActors;
        private TextView textViewPlot;
        private ImageView imageViewMovie;
        private FloatingActionButton fab;
        private Movie movie;

        public override int LayoutId
        {
            get
            {
                return Resource.Layout.movie_detail_activity;
            }
        }

        protected override void MyOnCreate()
        {

            SupportActionBar.Title = string.Empty;
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            Bundle bundle = Intent.Extras;
            fab = (FloatingActionButton)FindViewById(Resource.Id.fab);
            textViewTitleMovie = (TextView)FindViewById(Resource.Id.text_view_title_movie);
            textViewActors = (TextView)FindViewById(Resource.Id.text_view_actors);
            textViewPlot = (TextView)FindViewById(Resource.Id.text_view_plot);
            imageViewMovie = (ImageView)FindViewById(Resource.Id.imageView);

            fab.Click += delegate
            {
                if (movie != null)
                {
                    this.ShowInformation(GetString(Resource.String.remove_movie), null, () =>
                    {
                        movieRepository.Delete(movie);
                        SetResult(Result.Ok);
                        Finish();
                        Toast.MakeText(this, Resource.String.deleted_movie_successfully, ToastLength.Long).Show();
                    }, (dialog) =>
                     {
                         dialog.Dismiss();
                     }, GetString(Resource.String.ok), GetString(Resource.String.cancel));
                }
            };

            if (bundle != null)
            {
                long id = bundle.GetLong("id");
                movie = movieRepository.RetrieveById(id);

                LoadMovieToViewScreen(movie);
            }

        }

        private void LoadMovieToViewScreen(Movie movie)
        {

            if (movie == null)
            {
                Finish();
            }

            textViewTitleMovie.Text = movie.Title;
            textViewActors.Text = movie.Actors;
            textViewPlot.Text = movie.Plot;
            imageLoader.DisplayImage(movie.Poster, imageViewMovie, options);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}