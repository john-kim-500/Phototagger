using System.Drawing.Imaging;
using Phototagger.Faces;
using Phototagger.Imaging;
namespace Phototagger.UserOptions
{
    internal class HighlightRunner : IOptionRunner
    {
        private readonly string _inputFile;
        private readonly string _outputFile;

        public HighlightRunner(string inputFile, string outputFile) 
        { 
            if (!System.IO.File.Exists(inputFile)) throw new System.IO.FileNotFoundException(inputFile);

            _inputFile = inputFile;
            _outputFile = outputFile;
        }

        public void Run()
        {
            BitmapProvider bitmapProvider = new BitmapProvider();

            using (var bitmap = bitmapProvider.GetBitmap(_inputFile))
            {
                FacesDetector detector = new FacesDetector();
                var faces = detector.Find(bitmap);

                ImageHighlighter facesHighlighter = new ImageHighlighter();
                facesHighlighter.Highlight(bitmap, faces);

                bitmap.Save(_outputFile, ImageFormat.Png);
            }
        }
    }
}
