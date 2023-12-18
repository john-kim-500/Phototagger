using System.Collections.Generic;
using System.Drawing;

namespace Phototagger.Faces
{
    /// <summary>
    /// Filter to for handling overlapping face detection boundaries.
    /// </summary>
    public interface IOverlapFilter
    {
        List<Rectangle> Filter(IEnumerable<Rectangle> faces);
    }
}
