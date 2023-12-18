using Accord.Imaging.Filters;
using System.Collections.Generic;
using System.Drawing;
namespace Phototagger.Faces
{
    public class ImageHighlighter
    {
        public void Highlight(Bitmap bitmap, List<Rectangle> highlightSections)
        {
            var objectMarker = new RectanglesMarker(Color.Red);

            // Apply rectangles
            objectMarker.Rectangles = highlightSections;
            objectMarker.ApplyInPlace(bitmap); // overwrite the frame
        }
    }
}
