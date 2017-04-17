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

namespace MoviesApi.UI.Components
{
    public interface DrawableClickListener
    {
        void OnClick(DrawablePosition target);
    }

    public enum DrawablePosition
    {
        TOP, BOTTOM, LEFT, RIGHT, UP
    }
}