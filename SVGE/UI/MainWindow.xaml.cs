using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // ?
        RenderOptions.SetBitmapScalingMode(Art, BitmapScalingMode.NearestNeighbor);
        RenderOptions.SetEdgeMode(Art, EdgeMode.Aliased);
    }

    private Color SelectedColor => (PaletteButton.Background as SolidColorBrush).Color;

    private WriteableBitmap Bmp => Art.Source as WriteableBitmap;

    private int BitmapWidth => (int)UIPanel.ColumnDefinitions[1].ActualWidth;

    private int BitmapHeight => (int)ActualHeight;

    private void OnResize(object o, SizeChangedEventArgs e) => Art.Source = Bmp.Transform(BitmapWidth, BitmapHeight);

    private void OnPropertiesClick(object sender, RoutedEventArgs e) => MessageBox.Show(
        $"Window({(int)ActualHeight}x{(int)ActualWidth})\n" +
        $"Art({(int)Art?.ActualHeight}x{(int)Art?.ActualWidth})\n" +
        $"Bitmap({Bmp?.Height}x{Bmp?.Width})", "SVGE"
    );

    private void OnPaletteClick(object o, RoutedEventArgs e)
    {
        var palette = new PaletteWindow { Owner = this };
        if (palette.ShowDialog() == true)
        {
            (o as Button).Background = new SolidColorBrush(palette.SelectedColor);
        }
    }

    private void OnLClick(object o, MouseButtonEventArgs e) => Bmp.SetPixel(e.GetPosition(Art), SelectedColor);

    private void OnMove(object o, MouseEventArgs e)
    {


        if (e.LeftButton == MouseButtonState.Pressed)
        {
            Bmp.SetPixel(e.GetPosition(Art), SelectedColor);
        }
    }
}

