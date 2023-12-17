using Accord.Imaging.Filters;
using Image = Accord.Imaging.Image;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace Phototagger
{
    public class FaceClipper
    {
        public List<Bitmap> Clip(Bitmap bitmap, List<Rectangle> faces)
        {
            List<Bitmap> faceBitmaps = new List<Bitmap>();

            foreach(var face in faces)
            {
                Console.WriteLine($"BEGIN clip {face.Width} {face.Height} {face.Top} {face.Left}");
                faceBitmaps.Add(Clip(bitmap, face, PixelFormat.DontCare));
                Console.WriteLine("BEGIN end");
            }

            return faceBitmaps;
        }

        private static Bitmap Clip(Bitmap source, Rectangle rectangle, PixelFormat format)
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
