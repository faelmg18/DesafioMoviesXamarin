using System;

using Android.App;
using Android.Content;

namespace MoviesApi.UI.Components
{
    public static class DialogBuilder
    {
        static AlertDialog.Builder builder;
        private static AlertDialog alertDialog;

        public delegate void OnDialogDelegate(string TokenId);

        public static AlertDialog.Builder CreateDialog(Context context, string titlePositiveButton, string titleNegativeButton, string title, string content, bool showDialog, bool cancelable, bool apllyStyle = false)
        {

            return CreateDialog(context, titlePositiveButton, titleNegativeButton, title, content, showDialog, cancelable, null, null, apllyStyle);
        }

        public static AlertDialog.Builder CreateDialog(Context context, string titlePositiveButton, string titleNegativeButton, string title, string content, bool showDialog, bool cancelable, Action positiveButton, Action<AlertDialog> negativeButton, bool apllyStyle = false)
        {

            builder = createAlertDialogBuilder(context, title, content, cancelable, apllyStyle);
            putOnClickListener(titlePositiveButton, titleNegativeButton, builder, positiveButton, negativeButton);


            if (showDialog)
            {
                ((Activity)context).RunOnUiThread(() =>
                {
                    showDialogAlertDialogBuilder();
                });
            }

            return builder;
        }

        private static AlertDialog.Builder createAlertDialogBuilder(Context context, string title, string content, bool cancelable, bool apllyStyle)
        {
            AlertDialog.Builder builder;

            if (apllyStyle)
                builder = new AlertDialog.Builder(context, Resource.Style.AppCompatAlertDialogStyle);
            else
                builder = new AlertDialog.Builder(context);

            if (!string.IsNullOrEmpty(title))
            {
                builder.SetTitle(title);
            }

            if (!string.IsNullOrEmpty(content))
            {
                builder.SetMessage(content);
            }

            builder.SetCancelable(cancelable);

            return builder;
        }

        private static void putOnClickListener(string titleButtonPositive, string titleNegativeButton,
                                          AlertDialog.Builder builder, Action positiveButton, Action<AlertDialog> negativeButton)
        {
            if (!titleButtonPositive.Equals(string.Empty))
            {
                builder.SetPositiveButton(titleButtonPositive, (senderAlert, args) =>
                {
                    positiveButton?.Invoke();
                });
            }

            if (!titleNegativeButton.Equals(string.Empty))
            {
                builder.SetNegativeButton(titleNegativeButton, (senderAlert, args) =>
                {
                    if (negativeButton != null)
                    {
                        negativeButton?.Invoke(alertDialog);
                        return;
                    }
                    alertDialog.Dismiss();
                });
            }
        }

        public static ProgressDialog ShowProgressDialogInformation(Activity context, string titleDialog, string message)
        {
            return ShowProgressDialogInformation(context, titleDialog, message, true);
        }

        public static ProgressDialog ShowProgressDialogInformation(Activity context, string titleDialog, string message, bool isShowDialg)
        {
            ProgressDialog Dialog = null;
            Dialog = new ProgressDialog(context, Resource.Style.MyDialog);

            if (Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop)
            {
                int resourceStyle = Resource.Style.ProgressDialog;
                Dialog = new ProgressDialog(context, resourceStyle);
            }

            if (!string.IsNullOrEmpty(titleDialog))
                Dialog.SetTitle(message);

            if (!string.IsNullOrEmpty(message))
                Dialog.SetMessage(message);

            if (isShowDialg)
            {
                context.RunOnUiThread(() =>
                {
                    Dialog.Show();
                });
            }

            Dialog.Indeterminate = false;

            return Dialog;

        }

        public static AlertDialog.Builder ShowInformation(this Activity context, string message, string title = null, Action onClickOk = null, string titlePositiveButton = null, string titleNegativeButton = null, bool cancelabel = false, bool apllyStyle = false) =>
        CreateDialog(
          context
          , titlePositiveButton == null ? context.GetString(Resource.String.ok) : titlePositiveButton
           , titleNegativeButton == null ? string.Empty : titleNegativeButton
           , string.IsNullOrEmpty(title) ? context.GetString(Resource.String.app_name) : title
           , message
           , true
           , cancelabel
           , onClickOk
           , null
            , apllyStyle
           );

        public static AlertDialog.Builder ShowInformation(this Context context, string message, string title = null, Action onClickOk = null, string titlePositiveButton = null, string titleNegativeButton = null, bool cancelabel = false) =>
        CreateDialog
           (
           context
           , titlePositiveButton == null ? context.GetString(Resource.String.ok) : titlePositiveButton
           , titleNegativeButton == null ? string.Empty : titleNegativeButton
           , string.IsNullOrEmpty(title) ? context.GetString(Resource.String.app_name) : title
           , message
           , true
           , cancelabel
           , onClickOk
           , null
           );

        public static AlertDialog.Builder ShowInformation(this Context context, string message, string title = null, Action onClickOk = null, Action<AlertDialog> onClickCancel = null, string titlePositiveButton = null, string titleNegativeButton = null, bool cancelabel = false) =>
       CreateDialog
          (
          context
          , titlePositiveButton == null ? context.GetString(Resource.String.ok) : titlePositiveButton
          , titleNegativeButton == null ? string.Empty : titleNegativeButton
          , string.IsNullOrEmpty(title) ? context.GetString(Resource.String.app_name) : title
          , message
          , true
          , cancelabel
          , onClickOk
          , onClickCancel
          );

        public static void ShowErrorServerInformation(this Activity context, Action onClickOk = null) =>
          CreateDialog(context, context.GetString(Resource.String.ok), string.Empty, context.GetString(Resource.String.app_name), context.GetString(Resource.String.error_server_infomation), true, true, onClickOk, null);

        public static void ShowErrorServerInformation(this Activity context, bool applyStyle, Action onClickOk = null) =>
         CreateDialog(context, context.GetString(Resource.String.ok), string.Empty, context.GetString(Resource.String.app_name), context.GetString(Resource.String.error_server_infomation), true, true, onClickOk, null, applyStyle);

        private static void showDialogAlertDialogBuilder()
        {
            alertDialog = builder.Show();
        }

    }
}