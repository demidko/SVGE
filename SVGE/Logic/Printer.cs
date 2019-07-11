using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;


class Printer
{
    private readonly WriteableBitmap Bitmap;

    public Color CurrentColor = Brushes.Black.Color;

    public void Pixel(in Point p) => Bitmap.SetPixel(p, CurrentColor);

    public Printer(in WriteableBitmap bitmap) => Bitmap = bitmap;
}

