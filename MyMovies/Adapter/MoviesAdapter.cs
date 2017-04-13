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
using MyMovies.Libary.Model.Fundation;
using UniversalImageLoader.Core;

namespace MyMovies.Adapter
{
    public class MoviesAdapter : RecyclerView.Adapter
    {
        private List<Movie> _moviesList;
        private Activity _context;
        public Action<Movie, int, ImageView> _listener;

        private ImageLoader imageLoader = ImageLoader.Instance;
        private DisplayImageOptions options = new DisplayImageOptions.Builder()
                .CacheInMemory(true)
                .CacheOnDisk(true)
                .ShowImageForEmptyUri(Resource.Drawable.movieempty)
                .ShowImageOnFail(Resource.Drawable.movieempty)
                .BitmapConfig(Android.Graphics.Bitmap.Config.Rgb565).Build();


        public MoviesAdapter(Activity context, List<Movie> arrayList, Action<Movie, int, ImageView> listener)
        {
            _context = context;
            _moviesList = arrayList;
            _listener = listener;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //Setup and inflate your layout here
            var id = Resource.Layout.movie_item_row;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            return new MyViewHolder(itemView, _moviesList, _listener);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var movie = _moviesList[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as MyViewHolder;

            holder.title.Text = movie.Title;
            holder.genre.Text = movie.Genre;
            holder.year.Text = movie.Year;
            holder.ratingTextView.Text = movie.imdbRating;

            imageLoader.DisplayImage(movie.Poster, holder.imagePhotAlbum, options);

            holder.ItemView.Click += delegate
            {
                Intent intent = new Intent(_context, typeof(MainActivity));


            };



        }

        public override int ItemCount => _moviesList.Count;

    }

    public class MyViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
    {
        public TextView title, year, genre, ratingTextView;
        public ImageView imagePhotAlbum;
        private List<Movie> _moviesList;
        public Action<Movie, int, ImageView> _listener;


        public MyViewHolder(View view, List<Movie> arrayList, Action<Movie, int, ImageView> listener) : base(view)
        {

            title = (TextView)view.FindViewById(Resource.Id.nameTextView);
            genre = (TextView)view.FindViewById(Resource.Id.genre);
            year = (TextView)view.FindViewById(Resource.Id.year);
            imagePhotAlbum = (ImageView)view.FindViewById(Resource.Id.imageView);
            ratingTextView = (TextView)view.FindViewById(Resource.Id.ratingTextView);
        }


        public void OnClick(View v)
        {
            if (_listener != null)
            {
                Movie movie = _moviesList[AdapterPosition];
                _listener?.Invoke(movie, AdapterPosition, imagePhotAlbum);
            }
        }
    }
}