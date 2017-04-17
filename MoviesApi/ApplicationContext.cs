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
using MoviesApi.Libary.Infrastructure;
using MoviesApi.Services;
using MoviesApi.Libary;
using UniversalImageLoader.Core;

namespace MoviesApi
{
    [Application]
    public class ApplicationContext : Application, IApplication
    {

        public string ServerAddress { get; } = "http://www.omdbapi.com/{0}";

        public IContainer Services { get; }
        public bool IsConnected { get; set; }
        public static Context Context { get; set; }

        protected ApplicationContext(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
            Services = InitializeContainer();
        }

        public ApplicationContext()
        {
            Services = InitializeContainer();
        }

        private IContainer InitializeContainer()
        {
            return new Container();
        }

        public override void OnCreate()
        {
            base.OnCreate();

            ImageLoader.Instance.Init(ImageLoaderConfiguration.CreateDefault(this));
            Context = this;
            AppEnv.Application = this;

        }
    }
}