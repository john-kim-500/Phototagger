using System;
using System.Drawing.Imaging;
namespace accordNetProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Usage();
                return;
            }
            var inputFile = args[0];
            var outputFile = args[1];
            BitmapProvider bitmapProvider = new BitmapProvider();

            var bitmap = bitmapProvider.GetBitmap(inputFile);
            FacesDetector detector = new FacesDetector();
            var faces = detector.Find(bitmap);

            FacesHighlighter facesHighlighter = new FacesHighlighter();
            facesHighlighter.Highlight(bitmap, faces);

            bitmap.Save(outputFile, ImageFormat.Png);
        }

        private static void Usage()
        {
            Console.WriteLine("Phototagger.exe [image file] [output filename]");
        }
    }
}
