﻿
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using UniversalImageLoader.Core;
using Android.Graphics;

namespace MyMovies.UI.Screens.Fragments
{
    public abstract class BaseFragment : Fragment
    {

        public abstract void MyOnCreate(View view);
        public abstract int layoutId { get; }

        public View _view;

        public ImageLoader imageLoader = ImageLoader.Instance;
        public DisplayImageOptions options = new DisplayImageOptions.Builder()
                .CacheInMemory(true)
                .CacheOnDisk(true)
                .ShowImageForEmptyUri(Resource.Drawable.movieempty)
                .ShowImageOnFail(Resource.Drawable.movieempty)
                .BitmapConfig(Bitmap.Config.Rgb565).Build();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _view = LayoutInflater.From(Activity).Inflate(layoutId,
                   container, false);
            MyOnCreate(_view);
            return _view;
        }

        public void CloseKeyboard(View view)
        {
            if (view != null)
            {
                Android.Views.InputMethods.InputMethodManager imm = (Android.Views.InputMethods.InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }

        public View findViewById(int resourceId)
        {
            return _view.FindViewById(resourceId);
        }
    }
}