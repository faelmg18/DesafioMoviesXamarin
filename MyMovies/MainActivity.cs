using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Widget;
using MyMovies.Adapter;
using MyMovies.Engine.Model;
using V7 = Android.Support.V7.Widget;

using System.Collections.Generic;
using MyMovies.UI.Screens;
using System;

namespace MyMovies
{
    [Activity(Label = "MyMovies", MainLauncher = true, Theme = "@style/AppTheme", Icon = "@drawable/icon")]
    public class MainActivity : BaseActivity
    {
        private DrawerLayout _drawerLayout;
        private ListView _drawerList;
        private List<ItemNavigarionDrawer> _itemsNavigation;
        private MenuDrawerAdapter _adapter;
        private int oldPosition;

        public override int LayoutId
        {
            get
            {
                return Resource.Layout.activity_main;
            }
        }

        protected override void MyOnCreate()
        {
            _itemsNavigation = GetItemFromMenu();
            _adapter = new MenuDrawerAdapter(_itemsNavigation, this);
            _drawerList = (ListView)FindViewById(Resource.Id.left_drawer);

            _drawerList.Adapter = _adapter;
            _drawerList.ItemClick += ClickDrawer;

            V7.Toolbar toolbar = (V7.Toolbar)FindViewById(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);

            _drawerLayout = (DrawerLayout)FindViewById(Resource.Id.drawer_layout);

            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, _drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);

            _drawerLayout.SetDrawerListener(toggle);
            toggle.SyncState();


            //var movieRepository = this.Resolve<MovieRepository>();

            //OmdbApiMovies omdbApiMovies = new OmdbApiMovies(this);
            //omdbApiMovies.FindMovie("Ice", (movie) =>
            //{
            //    if (movie.ID > 0)
            //    {
            //        return;
            //    }
            //    movieRepository.SaveOrUpdate(movie);
            //});
        }


        private void ClickDrawer(object sender, AdapterView.ItemClickEventArgs e)
        {
            _drawerLayout.CloseDrawers();
            if (e.Position > 0)
                GotoFragment(e.Position);
        }


        private List<ItemNavigarionDrawer> GetItemFromMenu()
        {

            List<ItemNavigarionDrawer> listMenu = new List<ItemNavigarionDrawer>();

            listMenu.Add(new ItemNavigarionDrawer(true, GetString(Resource.String.app_name)));
            listMenu.Add(new ItemNavigarionDrawer(Resource.Integer.my_movies_menu_id, Resource.Drawable.ic_movie, GetString(Resource.String.my_movies)));
            listMenu.Add(new ItemNavigarionDrawer(Resource.Integer.find_movies_menu_id, Resource.Drawable.ic_magnify, GetString(Resource.String.find_movies)));

            return listMenu;
        }

        public void GotoFragment(int position, bool reloadFragment = false)
        {
            ItemNavigarionDrawer menuDrawer = _adapter.DataList[position];

            if (menuDrawer.Id == Resource.Integer.header_menu_id)
            {
                return;
            }

            SupportActionBar.Title = menuDrawer.NameTitleMenu;

            _adapter.SelectedPosition = position;
            _adapter.NotifyDataSetChanged();
            listItemClicked(menuDrawer.Id, reloadFragment);
            InvalidateOptionsMenu();
        }

        public void listItemClicked(int position, bool reloadFragment = false)
        {

            if (position == oldPosition && !reloadFragment)
                return;

            oldPosition = position;

           Android.Support.V4.App.Fragment fragment = null;
            switch (position)
            {
                case Resource.Integer.header_menu_id:
                    return;

                case Resource.Integer.my_movies_menu_id:
                    //fragment = new MyMoviesFragment();
                    break;
                case Resource.Integer.find_movies_menu_id:
                    //fragment = new FindMoviesFragment();
                    break;

            }

            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.content_frame, fragment)
                    .Commit();
        }
    }
}

