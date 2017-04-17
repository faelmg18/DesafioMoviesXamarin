using Android.Support.V7.Widget;
using MoviesApi.Libary.Model.Fundation;
using MoviesApi.Libary.Persistence;
using MoviesApi.Libary.Utils;
using System.Collections.Generic;
using Android.Views;
using System;
using MoviesApi.Utils;
using Android.Widget;
using MoviesApi.Adapter;

namespace MoviesApi.UI.Screens.Fragments
{
    public class MyMoviesFragment : BaseFragment
    {
        private RecyclerView _recyclerView;
        private MovieRepository _movieRepository;
        private LinkedHashMap<string, List<Movie>> _hasMapMovies;

        public override int layoutId
        {
            get
            {
                return  Resource.Layout.my_movies_list;
            }
        }

        public override void MyOnCreate(View view)
        {
            _recyclerView = (RecyclerView)FindViewById(Resource.Id.recyclerView);
            FindMovies();
        }

        private void FindMovies()
        {
            _movieRepository = Activity.Resolve<MovieRepository>();
            _hasMapMovies = _movieRepository.RetrieveAllGroupBy();

            var moviesCategorized = AddMoviesCategorizedOnAdapter();

            RecyclerView.LayoutManager mLayoutManager = new LinearLayoutManager(Activity);
            _recyclerView.SetLayoutManager(mLayoutManager);

            RecyclerView.Adapter adapter = new CategorizedMoviesAdapter(Activity, moviesCategorized);

            SetUpAdapter(adapter);
        }

        private List<CategorizedMovies> AddMoviesCategorizedOnAdapter()
        {
            List<CategorizedMovies> categorizedMovies = new List<CategorizedMovies>();
            foreach (var key in _hasMapMovies.D.Keys)
            {

                categorizedMovies.Add(new CategorizedMovies(_hasMapMovies[key], key));
            }
            return categorizedMovies;
        }

        private void SetUpAdapter(RecyclerView.Adapter mAdapter)
        {

            _recyclerView.HasFixedSize = true;
            _recyclerView.SetItemAnimator(new DefaultItemAnimator());
            _recyclerView.SetAdapter(mAdapter);
        }
    }
}