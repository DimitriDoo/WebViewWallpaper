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

namespace WebViewWallpaper
{
    /// <summary>
    /// Interaction logic for WallpaperSelectionWindow.xaml
    /// </summary>
    public partial class WallpaperSelectionWindow : Window
    {
        private WallpaperWindow _wallpaperWindow = new WallpaperWindow();
        private WallpaperDirectoriesViewModel _viewModel;

        public WallpaperSelectionWindow()
        {
            InitializeComponent();
            _viewModel = this.DataContext as WallpaperDirectoriesViewModel;
        }

        #region"Events"
        private void WallpaperDirectories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _wallpaperWindow.Close();
            Properties.Settings.Default.SelectedWallpaper = _viewModel.WallpaperDirectories[WallpaperDirectories.SelectedIndex].Wallpaper;

            _wallpaperWindow = new WallpaperWindow();
            _wallpaperWindow.Show();
        }

        private void WallpaperSelectionWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _wallpaperWindow.Show();
        }
        #endregion
    }
}
