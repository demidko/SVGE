
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
using SVGE.Properties;
using System.Collections.Specialized;


partial class PaletteWindow : Window
{
    public Color SelectedColor { private set; get; }

    public PaletteWindow()
    {
        InitializeComponent();
        if (Settings.Default.ColorsList == null)
        {
            return;
        }
        foreach (var i in Settings.Default.ColorsList)
        {
            var color = (Color)ColorConverter.ConvertFromString(i);
            var lst = ColorPanel.Children;
            lst.Insert(lst.Count - 1, CreateButton(color));
        }
    }

    private void OnColorSelected(object sender, RoutedEventArgs e)
    {
        SelectedColor = ((SolidColorBrush)((Button)sender).Background).Color;
        DialogResult = true;
        Close();
    }

    private Button CreateButton(Color color)
    {
        var button = new Button()
        {
            ContextMenu = new ContextMenu(),
            Background = new SolidColorBrush(color)
        };
        var item = new MenuItem
        {
            Header = "Delete",
            Icon = new Image
            {
                Source = new BitmapImage
                (
                    new Uri(@"pack://application:,,,/UI/Images/Delete.png")
                )
            }
        };
        item.Click += (o, e) => 
        {
            ColorPanel.Children.Remove(button);
            if(Settings.Default.ColorsList != null)
            {
                Settings.Default.ColorsList.Remove(color.ToString());
                Settings.Default.Save();
            }
        };
        button.ContextMenu.Items.Add(item);
        button.Click += OnColorSelected;
        return button;
    }

    private void NewColorClick(object sender, RoutedEventArgs e)
    {
        var w = new NewColorWindow { Owner = this };
        if (w.ShowDialog() != true)
        {
            return;
        }
        var lst = ColorPanel.Children;
        lst.Insert(lst.Count - 1, CreateButton(w.NewColor));
        if (Settings.Default.ColorsList == null)
        {
            Settings.Default.ColorsList = new StringCollection();
        }
        Settings.Default.ColorsList.Add(w.NewColor.ToString());
        Settings.Default.Save();
    }
}

