using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using WallpaperManager;

namespace WebViewWallpaper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WallpaperWindow : Window
    {
        public WallpaperWindow()
        {
            InitializeComponent();
            webView.Source = new Uri($@"{AppContext.BaseDirectory}\Wallpapers\{Properties.Settings.Default.SelectedWallpaper}\Wallpaper.html");
            this.Loaded += MainWindow_Loaded;
            this.Closing += MainWindow_Closing;
            PlaceWindow();
        }

        #region"Functions"

        private void PlaceWindow()
        {
            this.WindowState = WindowState.Maximized;
            this.Left = 0;
            this.Top = 0;
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
            this.Topmost = false;
            this.WindowStyle = WindowStyle.None;
            this.ShowInTaskbar = true;
        }
        
        #endregion

        #region"Events"
        
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Manager.SetWallPaper(new WindowInteropHelper(this).Handle);
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {

        }
        
        #endregion

    }
}