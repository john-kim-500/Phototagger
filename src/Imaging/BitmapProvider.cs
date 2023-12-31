﻿using System.Drawing;
using System.IO;

namespace Phototagger.Imaging
{
    internal class BitmapProvider
    {
        public Bitmap GetBitmap(string filename)
        {
            using (Stream bitmapStream = System.IO.File.Open(filename, FileMode.Open))
            {
                return new Bitmap(bitmapStream);
            }
        }
    }
}
