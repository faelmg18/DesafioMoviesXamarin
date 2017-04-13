using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using MyMovies.Libary.Infrastructure;
using MyMovies.Services;
using MyMovies.Libary;

namespace MyMovies
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

            //ImageLoader.Instance.Init(ImageLoaderConfiguration.CreateDefault(this));
            Context = this;
            AppEnv.Application = this;

        }
    }
}