using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

static class Bitmap
{
    public static WriteableBitmap Create(in int w, in int h)
    {
        var (x, y) = DPI.Dpi();
        return new WriteableBitmap(w, h, x, y, PixelFormats.Bgr32, null);
    }

    public static WriteableBitmap Transform(this WriteableBitmap img, in int w, in int h)
    {
        if (img != null)
        {

            var allPixelsRect = new Int32Rect(0, 0, img.PixelWidth, img.PixelHeight);
            const int bytesPerPixel = 4;
            var allPixelBytes = new byte[bytesPerPixel * img.PixelHeight * img.PixelWidth];
            img.CopyPixels(allPixelsRect, allPixelBytes, allPixelBytes.Length, 0);

            var res = Create(w, h);
            res.WritePixels(allPixelsRect, allPixelBytes, bytesPerPixel, 0);
            return res;
            
        }
        return Create(w, h);
    }

    public static void SetPixel(this WriteableBitmap img, in Point position, in Color color)
    {
        var onePixelRect = new Int32Rect((int)position.X, (int)position.Y, 1, 1);
        var onePixelBytes = new[] { color.B, color.G, color.R, color.A };
        img.WritePixels(onePixelRect, onePixelBytes, onePixelBytes.Length, 0);

    }
}