using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using MoviesApi.Libary.Persistence;
using MoviesApi.Utils;
using UniversalImageLoader.Core;

namespace MoviesApi.UI.Screens.Activities
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