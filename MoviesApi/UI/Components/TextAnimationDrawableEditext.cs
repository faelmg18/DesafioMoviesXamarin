using Android.Content;
using Android.Widget;
using Android.Text;
using Java.Lang;
using Android.Graphics.Drawables;
using Android.Animation;

namespace MoviesApi.UI.Components
{
    public class TextAnimationDrawableEditext : Java.Lang.Object, ITextWatcher
    {
        private EditText _editText;
        private bool _isModeEdit;
        private Context _context;

        public TextAnimationDrawableEditext(EditText editText, Context context)
        {
            _editText = editText;
            _context = context;
        }

        public void AfterTextChanged(IEditable s)
        {
          
        }

        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
            
        }

        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            if (s.ToString().Length > 0 && !_isModeEdit)
            {
                _isModeEdit = true;

                Drawable[] myTextViewCompoundDrawables = _editText.GetCompoundDrawables();

                foreach (Drawable drawable in myTextViewCompoundDrawables)
                {
                    if (drawable == null)
                        continue;

                    FadIn(drawable);
                }

            }
            else if (s.ToString().Length < 1)
            {
                _isModeEdit = false;
                Drawable[] myTextViewCompoundDrawables = _editText.GetCompoundDrawables();

                foreach (Drawable drawable in myTextViewCompoundDrawables)
                {
                    {

                        if (drawable == null)
                            continue;

                        FadOut(drawable);
                    }
                }
            }
        }

        private void FadIn(Drawable drawable)
        {
            AnimateView(drawable, 255);
        }

        private void FadOut(Drawable drawable)
        {
            AnimateView(drawable, 0);
        }

        private void AnimateView(Drawable drawable, int value)
        {
            ObjectAnimator animator = ObjectAnimator.OfPropertyValuesHolder(drawable, PropertyValuesHolder.OfInt("alpha", value));
            animator.SetTarget(drawable);
            animator.SetDuration(500);
            animator.Start();
        }
    }
}