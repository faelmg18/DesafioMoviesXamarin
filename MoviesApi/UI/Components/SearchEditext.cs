using System;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Util;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Views.InputMethods;

namespace MoviesApi.UI.Components
{
    class SearchEditext : Android.Support.V7.Widget.AppCompatEditText
    {
        private Drawable _drawableRight;
        private Drawable _drawableLeft;
        private Drawable _drawableTop;
        private Drawable _drawableBottom;
        private DrawableClickListener clickListener;
        int actionX, actionY;

        public SearchEditext(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public SearchEditext(Context context) : base(context)
        {

        }

        public SearchEditext(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }

        public SearchEditext(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        protected override void OnDraw(Canvas canvas)
        {
            ImeOptions = ImeAction.Done;
            base.OnDraw(canvas);
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
        }

        public override void SetCompoundDrawables(Drawable left, Drawable top, Drawable right, Drawable bottom)
        {
            if (left != null)
            {
                _drawableLeft = left;
            }
            if (right != null)
            {
                _drawableRight = right;
            }
            if (top != null)
            {
                _drawableTop = top;
            }
            if (bottom != null)
            {
                _drawableBottom = bottom;
            }

            base.SetCompoundDrawables(left, top, right, bottom);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            Rect bounds;

            if (e.Action == MotionEventActions.Down)
            {
                actionX = (int)e.GetX();
                actionY = (int)e.GetY();

                if (_drawableBottom != null
                        && _drawableBottom.Bounds.Contains(actionX, actionY))
                {
                    clickListener.OnClick(DrawablePosition.BOTTOM);
                    base.OnTouchEvent(e);
                }

                if (_drawableTop != null
                        && _drawableTop.Bounds.Contains(actionX, actionY))
                {
                    clickListener.OnClick(DrawablePosition.TOP);
                    return base.OnTouchEvent(e);
                }

                if (_drawableLeft != null)
                {
                    bounds = null;
                    bounds = _drawableLeft.Bounds;

                    int x, y;
                    int extraTapArea = (int)(13 * Resources.DisplayMetrics.Density + 0.5);

                    x = actionX;
                    y = actionY;
                    if (!bounds.Contains(actionX, actionY))
                    {
                        /** Gives the +20 area for tapping. */
                        x = (int)(actionX - extraTapArea);
                        y = (int)(actionY - extraTapArea);

                        if (x <= 0)
                            x = actionX;
                        if (y <= 0)
                            y = actionY;

                        /** Creates square from the smallest value */
                        if (x < y)
                        {
                            y = x;
                        }
                    }

                    if (bounds.Contains(x, y) && clickListener != null)
                    {
                        clickListener
                                .OnClick(DrawablePosition.LEFT);
                        e.Action = MotionEventActions.Cancel;
                        return false;
                    }
                }

                if (_drawableRight != null)
                {

                    bounds = null;
                    bounds = _drawableRight.Bounds;

                    int x, y;
                    int extraTapArea = 13;

                    /**
                     * IF USER CLICKS JUST OUT SIDE THE RECTANGLE OF THE DRAWABLE
                     * THAN ADD X AND SUBTRACT THE Y WITH SOME VALUE SO THAT AFTER
                     * CALCULATING X AND Y CO-ORDINATE LIES INTO THE DRAWBABLE
                     * BOUND. - this process help to increase the tappable area of
                     * the rectangle.
                     */
                    x = (int)(actionX + extraTapArea);
                    y = (int)(actionY - extraTapArea);

                    /**Since this is right drawable subtract the value of x from the width
                     * of view. so that width - tappedarea will result in x co-ordinate in drawable bound.
                     */
                    x = Width - x;

                    /*x can be negative if user taps at x co-ordinate just near the width.
                    * e.g views width = 300 and user taps 290. Then as per previous calculation
                    * 290 + 13 = 303. So subtract X from getWidth() will result in negative value.
                    * So to avoid this add the value previous added when x goes negative.
                    */

                    if (x <= 0)
                    {
                        x += extraTapArea;
                    }

                    /* If result after calculating for extra tappable area is negative.
                    * assign the original value so that after subtracting
                    * extratapping area value doesn't go into negative value.
                    */

                    if (y <= 0)
                        y = actionY;

                    /**If drawble bounds contains the x and y points then move ahead.*/
                    if (bounds.Contains(x, y) && clickListener != null)
                    {
                        clickListener
                                .OnClick(DrawablePosition.RIGHT);
                        e.Action = MotionEventActions.Cancel;
                        return false;
                    }
                    return base.OnTouchEvent(e);
                }
            }

            return base.OnTouchEvent(e);
        }

        protected override void JavaFinalize()
        {
            _drawableRight = null;
            _drawableBottom = null;
            _drawableLeft = null;
            _drawableTop = null;
            base.JavaFinalize();
        }

        public void SetDrawableClickListener(DrawableClickListener listener)
        {
            this.clickListener = listener;
        }

        public void AddDrawableAnimationOnTextChange(Context context)
        {
            AddTextChangedListener(new TextAnimationDrawableEditext(this, context));
            Text = string.Empty;
        }
    }
}