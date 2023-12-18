using Accord.Vision.Detection;
using System.Collections.Generic;
using System.Drawing;

namespace Phototagger.Faces
{
    /// <summary>
    /// Detects human faces in a bitmap file
    /// </summary>
    public class FacesDetector
    {
        private IOverlapFilter _filter;

        /// <summary>
        /// Creates a face detector.
        /// </summary>
        /// <remarks>
        /// Uses the <see cref="FaceOverlapFilter"/> to handle conflict or overlapping matches.
        /// </remarks>
        public FacesDetector()
            : this(new FaceOverlapFilter())
        {
        }

        public FacesDetector(IOverlapFilter overlapFilter)
        {
            _filter = overlapFilter;
        }

        /// <summary>
        /// Returns zero or more locations within bitmap that appear to be human faces
        /// </summary>
        public List<Rectangle> Find(Bitmap bitmap)
        { 
            // In order to use a HaarObjectDetector, first we have to tell it
            // which type of objects we would like to detect. And in a Haar detector,
            // different object classifiers are specified in terms of a HaarCascade.

            // The framework comes with some built-in cascades for common body
            // parts, such as Face and Nose. However, it is also possible to
            // load a cascade from cascade XML definitions in OpenCV 2.0 format.

            // In this example, we will be creating a cascade for a Face detector:
            var cascade = new Accord.Vision.Detection.Cascades.FaceHaarCascade();

            // Note: In the case we would like to load it from XML, we could use:
            // var cascade = HaarCascade.FromXml("filename.xml");

            // Now, create a new Haar object detector with the cascade:
            // Use Default (scan entire image).
            var detector = new HaarObjectDetector(cascade, minSize: 50,
                searchMode: ObjectDetectorSearchMode.Default);

   
            // We have to call ProcessFrame to detect all rectangles containing the 
            // object we are interested in
            Rectangle[] faces = detector.ProcessFrame(bitmap);

            return _filter.Filter(faces);
        }

    }
}
