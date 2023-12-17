using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Phototagger.UserOptions
{
    internal class FaceExtractorRunner : IOptionRunner
    {
        private readonly string _inputFile;
        private readonly string _outputPattern;

        public FaceExtractorRunner(string inputFile, string outputPattern)
        {
            if (!System.IO.File.Exists(inputFile)) throw new System.IO.FileNotFoundException(inputFile);

            _inputFile = inputFile;
            _outputPattern = outputPattern;
        }

        public void Run()
        {
            BitmapProvider bitmapProvider = new BitmapProvider();

            using (var bitmap = bitmapProvider.GetBitmap(_inputFile))
            {
                FacesDetector detector = new FacesDetector();
                var faces = detector.Find(bitmap);

                FaceClipper faceClipper = new FaceClipper();
                List<Bitmap> bitmaps = faceClipper.Clip(bitmap, faces);
                int count = 1;
                foreach (var faceBmp in bitmaps)
                {
                    var outputFile = $"{_outputPattern}_{count}.png";
                    Console.WriteLine($"Saving {outputFile}");
                    faceBmp.Save(outputFile, ImageFormat.Png);
                    count++;
                    faceBmp.Dispose();
                }
            }
        }
    }
}
