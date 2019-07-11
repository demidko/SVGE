using System.Windows;
using System.Windows.Media;

static class DPI
{
    ///// Исходный dpi (обычно 96)
    //[DllImport("user32.dll")] static extern int GetDpiForWindow(IntPtr hWnd);

    /// Возвращает количество точек на один дюйм по горизонтали (X) и по вертикали (Y)
    public static (double X, double Y) Dpi(this Window w)
    {
        // уже деленный на 96 dpi
        var m = PresentationSource
            .FromVisual(w)
            .CompositionTarget
            .TransformToDevice;
        return (m.M11 * 96, m.M22 * 96);
    }

    public static (double X, double Y) Dpi() => Application
        .Current
        .MainWindow
        .Dpi();
}

