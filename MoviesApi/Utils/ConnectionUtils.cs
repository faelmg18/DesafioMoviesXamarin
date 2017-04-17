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
using Android.Net;

namespace MoviesApi.Utils
{
    public static class ConnectionUtils
    {
        public static bool IsOnline(Context context)
        {
            ConnectivityManager cm =
                    (ConnectivityManager)context.GetSystemService(Context.ConnectivityService);
            NetworkInfo netInfo = cm.ActiveNetworkInfo;
            return netInfo != null && netInfo.IsConnectedOrConnecting;
        }
    }
}