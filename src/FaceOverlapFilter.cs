using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accordNetProject
{
    /// <summary>
    /// ObjectDetectorSearchMode.Default can have false positives (smaller rectangles) within a larger face.
    /// Assume that the largest rectangle is the one we're interested in.
    /// </summary>
    internal class FaceOverlapFilter : IOverlapFilter
    {
        public List<Rectangle> Filter(IEnumerable<Rectangle> faces)
        {
            List<Rectangle> filtered = new List<Rectangle>();
            foreach (var newFace in faces)
            {
                if (filtered.Count == 0)
                {
                    filtered.Add(newFace);
                    continue;
                }

                bool isNewFace = true;
                Rectangle? toRemoveRectangle = null;
                Rectangle? toAddRectangle = null;
                foreach (var filteredFace in filtered)
                {
                    // Case 1:  filteredFace is larger.  Do nothing
                    if (filteredFace.Contains(newFace))
                    {
                        isNewFace = false;
                        break;
                    }

                    // Case 2:  newFace is larger.  Remove filteredFace and replace with newFace
                    if (newFace.Contains(filteredFace))
                    {
                        isNewFace = false;
                        toRemoveRectangle = filteredFace;
                        toAddRectangle = newFace;
                        break;
                    }

                    // Case 3: A bit unexpected, but choose the larger rectangle
                    if (newFace.IntersectsWith(filteredFace))
                    {
                        isNewFace = false;
                        double areaNewFace = newFace.Height * newFace.Width;
                        double areafilteredFace = filteredFace.Height * filteredFace.Width;
                        if (areaNewFace > areafilteredFace)
                        {
                            toRemoveRectangle = filteredFace;
                            toAddRectangle = newFace;
                        }
                        break;
                    }
                }
                if (isNewFace)
                {
                    filtered.Add(newFace);
                    continue;
                }
                if (toRemoveRectangle.HasValue)
                {
                    filtered.Remove(toRemoveRectangle.Value);
                }

                if (toAddRectangle.HasValue)
                {
                    filtered.Add(toAddRectangle.Value);
                }
            }

            return filtered;
        }
    }
}
