using System;
using Android.Content;
using Android.Util;

namespace FyUtils.Droid {
    public static class UnitUtils {
        public static int GetPixelFromDp(Context context, float dp) {
            return (int)TypedValue.ApplyDimension(ComplexUnitType.Dip,
                                                  dp, context.Resources.DisplayMetrics);
        }

        public static int GetPixelFromSp(Context context, float sp) {
            return (int)TypedValue.ApplyDimension(ComplexUnitType.Sp,
                                                  sp, context.Resources.DisplayMetrics);
        }
    }
}
