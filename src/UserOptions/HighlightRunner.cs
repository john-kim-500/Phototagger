using System.Drawing.Imaging;

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

            var bitmap = bitmapProvider.GetBitmap(_inputFile);
            FacesDetector detector = new FacesDetector();
            var faces = detector.Find(bitmap);

            FacesHighlighter facesHighlighter = new FacesHighlighter();
            facesHighlighter.Highlight(bitmap, faces);

            bitmap.Save(_outputFile, ImageFormat.Png);
        }
    }
}
