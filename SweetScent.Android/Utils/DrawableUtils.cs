using Android.Content;
using Android.Graphics;

namespace SweetScent.Utils
{
    public static class DrawableUtils
    {
        public static Bitmap WriteTextOnDrawable(int drawableId, string text, int scale, Context context)
        {
            var bm = BitmapFactory.DecodeResource(context.Resources, drawableId)
                .Copy(Bitmap.Config.Argb8888, true);
            bm = Bitmap.CreateScaledBitmap(bm, bm.Width / scale, bm.Height / scale, false);

            var tf = Typeface.Create("Helvetica", TypefaceStyle.Bold);

            var paint = new Paint() {
                Color = Color.Black,
                TextAlign = Paint.Align.Center,
                TextSize = ConvertToPixels(context, 11)
            };
            paint.SetStyle(Paint.Style.Fill);
            paint.SetTypeface(tf);

            var textRect = new Rect();
            paint.GetTextBounds(text, 0, text.Length, textRect);

            Canvas canvas = new Canvas(bm);

            //If the text is bigger than the canvas , reduce the font size
            if (textRect.Width() >= (canvas.Width - 4))     //the padding on either sides is considered as 4, so as to appropriately fit in the text
                paint.TextSize = ConvertToPixels(context, 7);        //Scaling needs to be used for different dpi's

            //Calculate the positions
            int xPos = (canvas.Width / 2) - 2;     //-2 is for regulating the x position offset

            //"- ((paint.Descent() + paint.Ascent()) / 2)" is the distance from the baseline to the center.
            int yPos = (int)((canvas.Height / 2) - ((paint.Descent() + paint.Ascent()) / 2));

            canvas.DrawText(text, xPos, yPos - ConvertToPixels(context, 16), paint);

            return bm;
        }

        public static int ConvertToPixels(Context context, int nDP)
        {
            var conversionScale = context.Resources.DisplayMetrics.Density;
            return (int)((nDP * conversionScale) + 0.5f);
        }
    }
}
