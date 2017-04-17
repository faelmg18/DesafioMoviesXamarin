using System;

using Android.App;
using Android.Content;
using MoviesApi.Libary;
using System.Threading.Tasks;
using Android.Support.V4.Content;
using MoviesApi.UI.Components;

namespace MoviesApi.Utils
{
    public static class ActivityExtensions
    {
        public static TService Resolve<TService>(this Activity activity)
           where TService : class
        {
            return AppEnv.Application.Services.Resolve<TService>();
        }

        public static void ExecuteAsync<TResult>(this Activity activity,
          Task<TResult> method, Action<TResult> callback, Action<Exception> callbackError,
          string dialogMessage = null, string dialogTitle = null, bool showDialog = true)
        {

            activity.RunOnUiThread(() =>
            {

                if (dialogMessage == null)
                    dialogMessage = activity.GetString(Resource.String.wait);

                var dialog = DialogBuilder.ShowProgressDialogInformation(activity, dialogTitle ?? string.Empty, dialogMessage, showDialog);
                dialog.SetCancelable(false);
                activity.ExecuteSync(() =>
                {
                    try
                    {
                        method.ContinueWith(x => activity.ExecuteSync(() =>
                        {
                            try
                            {
                                callback(x.Result);
                                if (dialog != null)
                                {
                                    activity.RunOnUiThread(dialog.Dismiss);
                                }
                            }
                            catch (Exception exception)
                            {
                                dialog.Dismiss();
                                callbackError(exception);
                            }

                        }));
                    }
                    catch (Exception exception)
                    {
                        dialog.Dismiss();
                        callbackError(exception);
                    }
                });
            });
        }

        public static void ExecuteSync(this Context activity, Action method)
        {
            try
            {
                method();
            }
            catch (Exception e)
            {
                throw;

            }
        }
        public static Android.Graphics.Color GetGraphicsColorApp(this Activity activity, int color) =>
         new Android.Graphics.Color(ContextCompat.GetColor(activity, color));
    }
}