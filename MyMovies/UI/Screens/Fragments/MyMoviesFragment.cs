using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MyMovies.Libary.Persistence;
using MyMovies.Libary.Utils;
using MyMovies.Libary.Model.Fundation;
using Android.Widget;
using MyMovies.Adapter;

namespace MyMovies.UI.Screens.Fragments
{
    public class MyMoviesFragment : BaseFragment
    {
        public static int MovieDeleted = 012;
        private Android.Support.V7.Widget.RecyclerView recyclerView;
        private MoviesAdapter mAdapter;
        private MovieRepository movieRepository;
        private LinkedHashMap<String, List<Movie>> hasMapMovies;

        public override int layoutId
        {
            get
            {
                return Resource.Layout.my_movies_list;
            }
        }

        public override void MyOnCreate(View view)
        {

        }
    }
}