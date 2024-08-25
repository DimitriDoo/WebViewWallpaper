using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WallpaperManager
{
    public class Manager
    {
        #region"DLL Imports"

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, IntPtr windowTitle);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SendMessageTimeout(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam, SendMessageTimeoutFlags fuFlags, uint uTimeout, out IntPtr lpdwResult);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);


        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        private const int SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 1;
        private const int SPIF_SENDCHANGE = 2;

        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint WM_CLOSE = 0x0010;
        private static IntPtr _workerw;

        private enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL = 0x0000,
            SMTO_BLOCK = 0x0001,
            SMTO_ABORTIFHUNG = 0x0002,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
        }

        #endregion

        #region"Functions"
        public static void SetWallPaper(IntPtr windowHandler)
        {
            IntPtr hwnd = windowHandler;
            IntPtr progman = FindWindow("Progman", null);;
            _workerw = IntPtr.Zero;

            // Send a message to   to spawn a WorkerW
            SendMessageTimeout(progman, 0x052C, IntPtr.Zero, IntPtr.Zero, SendMessageTimeoutFlags.SMTO_NORMAL, 1000, out _);

            // Find the WorkerW window
            EnumWindows((tophandle, topparamhandle) =>
            {
                IntPtr p = FindWindowEx(tophandle, IntPtr.Zero, "SHELLDLL_DefView", IntPtr.Zero);
                if (p != IntPtr.Zero)
                {
                    _workerw = FindWindowEx(IntPtr.Zero, tophandle, "WorkerW", IntPtr.Zero);
                }
                return true;
            }, IntPtr.Zero);

            // Set the parent of the WPF window to the WorkerW window
            if (_workerw != IntPtr.Zero)
            {
                SetParent(hwnd, _workerw);
            }
        }
        #endregion

    }
}
