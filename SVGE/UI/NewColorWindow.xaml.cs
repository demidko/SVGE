using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


public partial class NewColorWindow : Window
{
    public Color NewColor => (PaletteBlock.Fill as SolidColorBrush).Color;

    public NewColorWindow() => InitializeComponent();

    private byte Red, Green, Blue;

    private void OnCancelClick(object sender, RoutedEventArgs e) => Close();

    private void OnOkClick(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    private void Sync() => PaletteBlock.Fill = new SolidColorBrush
    (
        new Color { R = Red, G = Green, B = Blue, A = 255 }
    );

    private void OnRedSliderMove(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        Red = (byte)(sender as Slider).Value;
        Sync();
    }

    private void OnGreenSliderMove(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        Green = (byte)(sender as Slider).Value;
        Sync();
    }

    private void OnBlueSliderMove(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        Blue = (byte)(sender as Slider).Value;
        Sync();
    }
}

