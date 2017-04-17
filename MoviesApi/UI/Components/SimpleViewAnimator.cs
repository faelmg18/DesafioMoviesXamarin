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
using Android.Util;
using Android.Views.Animations;

namespace MoviesApi.UI.Components
{
    public class SimpleViewAnimator : LinearLayout
    {
        private Animation inAnimation;
        private Animation outAnimation;

        public SimpleViewAnimator(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public SimpleViewAnimator(Context context) : base(context)
        {

        }

        public SimpleViewAnimator(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {

        }

        public SimpleViewAnimator(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }

        public SimpleViewAnimator(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        public void SetInAnimation(Animation inAnimation)
        {
            this.inAnimation = inAnimation;
        }

        public void SetOutAnimation(Animation outAnimation)
        {
            this.outAnimation = outAnimation;
        }


        public override ViewStates Visibility
        {
            get
            {
                return base.Visibility;
            }

            set
            {
                if (Visibility != value)
                {
                    if (value == ViewStates.Visible)
                    {
                        if (inAnimation != null) StartAnimation(inAnimation);
                    }
                    else if ((value == ViewStates.Invisible) || (value == ViewStates.Gone))
                    {
                        if (outAnimation != null) StartAnimation(outAnimation);
                    }
                }

                base.Visibility = value;
            }
        }

    }
}