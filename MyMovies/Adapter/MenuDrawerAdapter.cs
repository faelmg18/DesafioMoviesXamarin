using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;
using UniversalImageLoader.Core;
using MyMovies.Engine.Model;
using MyMovies.Utils;

namespace MyMovies.Adapter
{
    class MenuDrawerAdapter : BaseAdapter<ItemNavigarionDrawer>
    {
        ImageView _imageMenu;
        TextView _titleMenu;
        public ImageLoader imageLoader = ImageLoader.Instance;
        public List<ItemNavigarionDrawer> DataList { get; set; }

        public List<ItemNavigarionDrawer> ItemNavigation { get; set; }
        public int SelectedPosition { get; set; }
        public Activity _activity { get; set; }

        public MenuDrawerAdapter(List<ItemNavigarionDrawer> itemNavigation, Activity activity)
        {
            ItemNavigation = itemNavigation;
            _activity = activity;
            SelectedPosition = 1;
            DataList = itemNavigation;
        }

        public ItemNavigarionDrawer GetItemAtPosition(int position) => ItemNavigation[position];

        public override ItemNavigarionDrawer this[int position] { get { return ItemNavigation[position]; } }

        public override int Count { get { return ItemNavigation.Count; } }

        public override long GetItemId(int position) => ItemNavigation[position].Id;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ItemNavigarionDrawer item = ItemNavigation[position];
            View _view = null;


            if (item.IsHeaderMenu)
            {
                _view = convertView ?? LayoutInflater.FromContext(_activity).Inflate(Resource.Layout.nav_header, null);

                TextView nameUser = _view.FindViewById<TextView>(Resource.Id.name_user);
                ImageView imageProfile = _view.FindViewById<ImageView>(Resource.Id.image_profile);


                nameUser.Text = item.NameUser;
            }
            else
            {
                _view = convertView ?? _activity.LayoutInflater.Inflate(
                      Resource.Layout.menu_drawe_item, parent, false);

                _titleMenu = _view.FindViewById<TextView>(Resource.Id.text_view_item_drawer);
                _titleMenu.Text = item.NameTitleMenu;

                _imageMenu = _view.FindViewById<ImageView>(Resource.Id.image_view_item_drawer);
                _imageMenu.SetImageResource(item.ImageResource);

            }

            if (SelectedPosition == position)
            {
                _view.SetBackgroundResource(Resource.Color.selected);
                _imageMenu.SetColorFilter(_activity.GetGraphicsColorApp(Resource.Color.colorPrimary));
                _titleMenu.SetTextColor(_activity.GetGraphicsColorApp(Resource.Color.colorPrimary));
            }
            else
            {
                _view.SetBackgroundResource(Resource.Color.white);
                if (_imageMenu != null)
                {
                    _imageMenu.SetColorFilter(null);
                    _titleMenu.SetTextColor(_activity.GetGraphicsColorApp(Android.Resource.Color.PrimaryTextLight));
                }
            }

            return _view;
        }
    }
}