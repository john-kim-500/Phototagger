using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using Accord.Imaging;
using Accord.Vision;
using Accord.Vision.Detection;
using Accord.Imaging.Filters;
using System.IO;
namespace Phototagger
{
    public class FacesHighlighter
    {
        public void Highlight(Bitmap bitmap, List<Rectangle> faces)
        {
            var objectMarker = new RectanglesMarker(Color.Red);

            // Apply rectangles
            objectMarker.Rectangles = faces;
            objectMarker.ApplyInPlace(bitmap); // overwrite the frame

        }
    }
}
