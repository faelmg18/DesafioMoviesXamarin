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
using MoviesApi.UI.Components;
using MoviesApi.Libary.Persistence;
using Android.Support.Design.Widget;
using MoviesApi.OmdbApi;
using MoviesApi.Utils;
using MoviesApi.Libary.Model.Fundation;

namespace MoviesApi.UI.Screens.Fragments
{
    public class FindMoviesFragment : BaseFragment
    {
        private SearchEditext searchEditext;
        private MovieRepository movieRepository;
        private OmdbApiMovies omdbApi;
        private TextView textViewTitleMovie;
        private TextView textViewActors;
        private TextView textViewPlot;
        private SimpleViewAnimator viewAnimator;
        private FloatingActionButton fabSave;
        private ImageView imageViewMovie;
        private Movie movieToSave;

        public override int layoutId
        {
            get
            {
                return Resource.Layout.find_movies_frament;
            }
        }

        public override void MyOnCreate(View view)
        {
            movieRepository = Activity.Resolve<MovieRepository>();

            omdbApi = new OmdbApiMovies(Activity);

            viewAnimator = (SimpleViewAnimator)FindViewById(Resource.Id.animated_view);

            searchEditext = (SearchEditext)FindViewById(Resource.Id.edit_text_serach_movie);

            searchEditext.SetDrawableClickListener(new SearchClick(this));


            searchEditext.AddDrawableAnimationOnTextChange(Activity);
            searchEditext.ImeOptions = Android.Views.InputMethods.ImeAction.Done;

            textViewTitleMovie = (TextView)FindViewById(Resource.Id.text_view_title_movie);
            textViewActors = (TextView)FindViewById(Resource.Id.text_view_actors);
            textViewPlot = (TextView)FindViewById(Resource.Id.text_view_plot);
            imageViewMovie = (ImageView)FindViewById(Resource.Id.imageView);

            fabSave = (FloatingActionButton)FindViewById(Resource.Id.fab);

            fabSave.Click += delegate 
            {
                if (movieToSave != null)
                {
                    movieRepository.Save(movieToSave);
                    Toast.MakeText(Activity, Resource.String.movie_saved, ToastLength.Long).Show();
                    movieToSave = null;
                }
            };


            viewAnimator.SetInAnimation(Android.Views.Animations.AnimationUtils.LoadAnimation(
                  Activity,
                   Resource.Animation.slide_up));

            viewAnimator.SetOutAnimation(Android.Views.Animations.AnimationUtils.LoadAnimation(
                    Activity,
                    Resource.Animation.slide_down));

            PerformSearch();
        }

        private void PerformSearch()
        {
            searchEditext.ClearFocus();
            Android.Views.InputMethods.InputMethodManager inn = (Android.Views.InputMethods.InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
            inn.HideSoftInputFromWindow(searchEditext.WindowToken, 0);
        }

        private void FindMovies()
        {
            string movieTitle = searchEditext.Text.ToString();
            CleanMoveToView();
            List<Movie> movies = movieRepository.RetrieveAllByName(movieTitle);

            if (movies.Count == 0)
            {
                if (ConnectionUtils.IsOnline(Activity))
                {
                    omdbApi.FindMovie(movieTitle, (movie) =>
                    {
                        movieToSave = movie;
                        LoadMovieToViewScreen(movie);
                    });
                }
            }
            else
            {
                Movie movie = movies[0];
                LoadMovieToViewScreen(movie);
            }

            searchEditext.Text = string.Empty;
        }

        public void CleanMoveToView()
        {
            CloseKeyboard(searchEditext);
            textViewTitleMovie.Text = string.Empty;
            textViewActors.Text = string.Empty;
            textViewPlot.Text = string.Empty;
            viewAnimator.Visibility = ViewStates.Gone;
            imageViewMovie.SetImageBitmap(null);
        }

        private void LoadMovieToViewScreen(Movie movie)
        {
            if (bool.Parse(movie.Response))
            {
                textViewTitleMovie.Text = movie.Title;
                textViewActors.Text = movie.Actors;
                textViewPlot.Text = movie.Plot;
                viewAnimator.Visibility = ViewStates.Visible;
                imageLoader.DisplayImage(movie.Poster, imageViewMovie, options);
            }
            else
            {
                Toast.MakeText(Activity, Resource.String.movie_not_found, ToastLength.Long).Show();
            }
        }

        public class SearchClick : DrawableClickListener
        {
            FindMoviesFragment _target;
            public SearchClick(FindMoviesFragment target)
            {
                _target = target;
            }
            public void OnClick(DrawablePosition result)
            {
                switch (result)
                {

                    case DrawablePosition.RIGHT:
                        _target.FindMovies();
                        break;

                }
            }
        }
    }
}