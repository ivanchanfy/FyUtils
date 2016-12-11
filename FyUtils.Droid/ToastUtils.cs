using System;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace FyUtils.Droid {
    public static class ToastUtils {
        public static void ShowToast(Context context, string message, ToastLength duration = ToastLength.Short) {
            Toast.MakeText(context, message, duration).Show();
        }

        public static void ShowToast(Context context, int resId, ToastLength duration = ToastLength.Short) {
            Toast.MakeText(context, resId, duration).Show();
        }

        public static void ShowToast(Context context, View view, ToastLength duration = ToastLength.Short) {
            var toast = new Toast(context);
            toast.View = view;
            toast.Duration = duration;
            toast.Show();
        }
    }
}
