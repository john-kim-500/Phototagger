using System.Collections.Generic;
using System.Drawing;

namespace Phototagger.Imaging
{
    public class ImagesClipper
    {
        /// <summary>
        /// Clip out images
        /// </summary>
        public List<Bitmap> Clip(Bitmap bitmap, List<Rectangle> clipLocations)
        {
            List<Bitmap> clips = new List<Bitmap>();

            foreach(var clipLocation in clipLocations)
            {
                clips.Add(Clip(bitmap, clipLocation));
            }

            return clips;
        }

        // Clip out image based on bounding rectangle and return new bitmap
        private static Bitmap Clip(Bitmap source, Rectangle rectangle)
        {
            int width = rectangle.Width;
            int height = rectangle.Height;
            Bitmap bitmap = new Bitmap(width, height, source.PixelFormat);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                var left = rectangle.Right - rectangle.Width;
                graphics.DrawImage(source, 0, 0, rectangle, GraphicsUnit.Pixel);
            }

            return bitmap;
        }
    }
}
