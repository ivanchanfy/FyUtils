using System;
using Android.Graphics;

namespace FyUtils.Droid {
    public static class ImageUtils {
        public static Bitmap ResizeBitmap(Bitmap bitmap, int width, int height) {
            return Bitmap.CreateScaledBitmap(bitmap, width, height, true);
        }

        public static Bitmap ResizeBitmap(Bitmap bitmap, float scale) {
            int width = Convert.ToInt32(bitmap.Width * scale);
            int height = Convert.ToInt32(bitmap.Height * scale);

            return ResizeBitmap(bitmap, width, height);
        }

        public static Bitmap ResizeBitmapWithHeight(Bitmap bitmap, int height) {
            float scale = Convert.ToSingle(height) / Convert.ToSingle(bitmap.Height);
            return ResizeBitmap(bitmap, scale);
        }

        public static Bitmap ResizeBitmapWithWidth(Bitmap bitmap, int width) {
            float scale = Convert.ToSingle(width) / Convert.ToSingle(bitmap.Width);
            return ResizeBitmap(bitmap, scale);
        }
    }
}
