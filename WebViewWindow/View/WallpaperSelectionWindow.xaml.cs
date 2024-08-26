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
using System.Data;
using System.IO;
using WebViewWallpaper.ViewModels;
using WebViewWindow;

namespace WebViewWallpaper
{
    /// <summary>
    /// Interaction logic for WallpaperSelectionWindow.xaml
    /// </summary>
    public partial class WallpaperSelectionWindow : Window
    {
        private WallpaperWindow wallpaperWindow = new WallpaperWindow();

        public WallpaperSelectionWindow()
        {
            InitializeComponent();
        }

        #region"Events"
        private void WallpaperDirectories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Read Config
        //Select Wallpaper
        private void WallpaperSelectionWindow_Loaded(object sender, RoutedEventArgs e)
        {
            wallpaperWindow.Show();
        }
        #endregion
    }
}
