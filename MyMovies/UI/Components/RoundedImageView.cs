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
using Android.Graphics;
using Android.Graphics.Drawables;
using static Android.Graphics.AvoidXfermode;

namespace MyMovies.UI.Components
{
    public class RoundedImageView : ImageView
    {
        public RoundedImageView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public RoundedImageView(Context context) : base(context)
        {

        }

        public RoundedImageView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {

        }

        public RoundedImageView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }

        public RoundedImageView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        protected override void OnDraw(Canvas canvas)
        {
            Drawable drawable = Drawable;

            if (drawable == null)
            {
                return;
            }

            if (Width == 0 || Height == 0)
            {
                return;
            }
            Bitmap b = ((BitmapDrawable)drawable).Bitmap;
            Bitmap bitmap = b.Copy(Bitmap.Config.Argb8888, true);

            int w = Width;

            int h = Height;

            Bitmap roundBitmap = GetCroppedBitmap(bitmap, w);
            canvas.DrawBitmap(roundBitmap, 0, 0, null);
        }

        public static Bitmap GetCroppedBitmap(Bitmap bmp, int radius)
        {
            Bitmap sbmp;

            if (bmp.Width != radius || bmp.Height != radius)
            {
                float smallest = Math.Min(bmp.Width, bmp.Height);
                float factor = smallest / radius;
                sbmp = Bitmap.CreateScaledBitmap(bmp,
                        (int)(bmp.Width / factor),
                        (int)(bmp.Height / factor), false);
            }
            else
            {
                sbmp = bmp;
            }

            Bitmap output = Bitmap.CreateBitmap(radius, radius, Bitmap.Config.Argb8888);
            Canvas canvas = new Canvas(output);

            string color = "#BAB399";
            Paint paint = new Paint();
            Rect rect = new Rect(0, 0, radius, radius);

            paint.AntiAlias = true;
            paint.FilterBitmap = true;
            paint.Dither = true;
            canvas.DrawARGB(0, 0, 0, 0);
            paint.Color = Color.ParseColor(color);
            canvas.DrawCircle(radius / 2 + 0.7f, radius / 2 + 0.7f,
                    radius / 2 + 0.1f, paint);
            paint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.SrcIn));
            canvas.DrawBitmap(sbmp, rect, rect, paint);

            return output;
        }
    }
}