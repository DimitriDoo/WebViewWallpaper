using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebViewWallpaper.Models;

namespace WebViewWallpaper.ViewModels
{
    public class WallpaperDirectoriesViewModel
    {
        public WallpaperDirectoriesViewModel() 
        {
            List<WallpaperDirectory> dirs = new List<WallpaperDirectory>();
            foreach (string dir in Directory.GetDirectories($@"{AppContext.BaseDirectory}\Wallpapers\"))
            {
                string dirName = dir.Remove(0, $@"{AppContext.BaseDirectory}\Wallpapers\".Length);
                dirs.Add(new WallpaperDirectory() { Wallpaper = dirName });
            }
            this.WallpaperDirectories = new ObservableCollection<WallpaperDirectory>(dirs);
        }
        public ObservableCollection<WallpaperDirectory> WallpaperDirectories { get; set; }
    }
}
