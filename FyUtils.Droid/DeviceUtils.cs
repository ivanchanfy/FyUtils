using System;
using Android.Content;
using Android.OS;
using Java.IO;

namespace FyUtils.Droid {
    public static class DeviceUtils {
        private const string ActionRequestShutdown = "android.intent.action.ACTION_REQUEST_SHUTDOWN";
        private const string ExtraKeyConfirm = "android.intent.extra.KEY_CONFIRM";

        public static BuildVersionCodes SdkVersion {
            get {
                return Build.VERSION.SdkInt;
            }
        }

        public static string Manufacturer {
            get {
                return Build.Manufacturer;
            }
        }

        public static string Model {
            get {
                return Build.Model ?? "";
            }
        }

        public static bool IsRoot() {
            string su = "su";
            string[] folders = {"/system/bin/", "/system/xbin/", "/sbin/", "/system/sd/xbin/", "/system/bin/failsafe/", "/data/local/xbin/", "/data/local/bin/", "/data/local/"};

            foreach (string folder in folders) {
                if (new File(folder + su).Exists()) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Shutdown, ROOT REQUIRED.
        /// </summary>
        /// <param name="context">Context.</param>
        public static void Shutdown(Context context) {
            Intent intent = new Intent(ActionRequestShutdown);
            intent.PutExtra(ExtraKeyConfirm, false);
            intent.SetFlags(ActivityFlags.NewTask);
            context.StartActivity(intent);
        }

        /// <summary>
        /// Reboot, ROOT REQUIRED.
        /// </summary>
        /// <param name="context">Context.</param>
        public static void Reboot(Context context) {
            Intent intent = new Intent(Intent.ActionReboot);
            intent.PutExtra("nowait", 1);
            intent.PutExtra("interval", 1);
            intent.PutExtra("window", 0);
            context.SendBroadcast(intent);
        }

        /// <summary>
        /// Reboot with a reason, ROOT REQUIRED.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="reason">Reason.</param>
        public static void Reboot(Context context, string reason) {
            PowerManager powerManager = (PowerManager)context.GetSystemService(Context.PowerService);
            try {
                powerManager.Reboot(reason);
            } catch (Exception e) {
                System.Console.WriteLine(e.StackTrace);
            }
        }
    }
}
