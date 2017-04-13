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
using Android.Support.V7.App;
using MyMovies.Libary.Persistence;
using UniversalImageLoader.Core;
using Android.Graphics;
using MyMovies.Utils;

namespace MyMovies.UI.Screens
{
    public abstract class BaseActivity : AppCompatActivity
    {
        protected abstract void MyOnCreate();

        public abstract int LayoutId { get; }


        protected MovieRepository movieRepository;
        protected ImageLoader imageLoader = ImageLoader.Instance;
        protected DisplayImageOptions options = new DisplayImageOptions.Builder()
                .CacheInMemory(true)
                .CacheOnDisk(true)
                .ShowImageForEmptyUri(Resource.Drawable.movieempty)
                .ShowImageOnFail(Resource.Drawable.movieempty)
                .BitmapConfig(Bitmap.Config.Rgb565).Build();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(LayoutId);
            movieRepository = this.Resolve<MovieRepository>();
            MyOnCreate();
        }
    }
}