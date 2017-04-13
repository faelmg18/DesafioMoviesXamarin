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

namespace MyMovies.Adapter
{
    public abstract class BaseListViewAdapter<T> : BaseAdapter
    {
        public List<T> DataList { get; set; }
        public Context Context { get; set; }
        private View View { get; set; }
        public int CurrentPosition { get; set; }
        public T Element { get { return this[CurrentPosition]; } }
        public BaseListViewAdapter(List<T> dataList, Context context)
        {
            DataList = dataList;
            Context = context;
        }

        public override int Count { get { return DataList.Count; } }

        public T this[int position] { get { return DataList[position]; } }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            CurrentPosition = position;
            View view = LayoutInflater.From(Context).Inflate(LayoutId, null);
            View = view;
            return MyGetView(position, view, parent);

        }

        public T FindViewById<T>(int id) where T : View
        {
            return View.FindViewById<T>(id);
        }

        protected abstract int LayoutId { get; }

        protected abstract View MyGetView(int position, View convertView, ViewGroup parent);
    }
}