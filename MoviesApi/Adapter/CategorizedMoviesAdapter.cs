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
using Android.Support.V7.Widget;
using MoviesApi.Libary.Model.Fundation;
using MoviesApi.UI.Components;

namespace MoviesApi.Adapter
{
    public class CategorizedMoviesAdapter : RecyclerView.Adapter
    {
        private List<CategorizedMovies> CategorizedMovies { get; set; }
        private Activity Activity { get; set; }

        public CategorizedMoviesAdapter(Activity activity, List<CategorizedMovies> categorizedMovies)
        {
            CategorizedMovies = categorizedMovies;
            Activity = activity;
        }

        public void AddMovies(CategorizedMovies movieCategorized)
        {
            CategorizedMovies.Add(movieCategorized);
        }

        public class CategorizedViewHolder : RecyclerView.ViewHolder
        {
            public RecyclerView recyclerView;
            public TextView textViewtextGenre;

            public CategorizedViewHolder(View view) : base(view)
            {

                recyclerView = (RecyclerView)view.FindViewById(Resource.Id.recyclerView);
                textViewtextGenre = (TextView)view.FindViewById(Resource.Id.text_view_movie_genre);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            var id = Resource.Layout.categorized_movies_item;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            return new CategorizedViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var _movies = CategorizedMovies[position];

            var _holder = holder as CategorizedViewHolder;

            List<Movie> movies = _movies.Movies;

            MoviesAdapter mAdapter = new MoviesAdapter(Activity, movies, (a, b, c) =>
            {

            });

            _holder.textViewtextGenre.Text = _movies.Genere;

            _holder.recyclerView.SetLayoutManager(new LinearLayoutManager(_holder
                    .recyclerView.Context, LinearLayoutManager.Horizontal, false));

            //holder.recyclerView.se.SetOnFlingListener(null);

            new StartSnapHelper().AttachToRecyclerView(_holder.recyclerView);

            _holder.recyclerView.SetItemAnimator(new DefaultItemAnimator());
            _holder.recyclerView.SetAdapter(mAdapter);
        }

        public override int ItemCount
        {
            get { return CategorizedMovies.Count; }
        }
    }
}