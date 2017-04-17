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
using Android.Support.V4.App;
using Android.Support.V4.Util;

namespace MoviesApi.Utils
{
    public class SharedElementHotFix
    {
        public Bundle SharedElementBundle(Activity activity, View view, String sharedelemname)
        {
            ActivityOptionsCompat options = ActivityOptionsCompat.MakeSceneTransitionAnimation(activity, view, sharedelemname);
            return options.ToBundle();
        }

        public Bundle SharedElementBundle(Activity activity, params Pair[] sharedelems)
        {
            ActivityOptionsCompat options = ActivityOptionsCompat.MakeSceneTransitionAnimation(activity, sharedelems);
            return options.ToBundle();
        }
    }
}