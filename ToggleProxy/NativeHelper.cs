using System;
using System.Runtime.InteropServices;

namespace ToggleProxy
{
    public static class NativeHelper
    {
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool InternetSetOption(
            IntPtr hInternet,
            SET_OPTIONS option,
            IntPtr buffer,
            int bufferLength);

        public enum SET_OPTIONS
        {
            INTERNET_OPTION_REFRESH = 37,
            INTERNET_OPTION_SETTINGS_CHANGED = 39,
            INTERNET_OPTION_PER_CONNECTION_OPTION = 75
        };

        public static void RefreshInternetExplorerSettings()
        {
            InternetSetOption(IntPtr.Zero, SET_OPTIONS.INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, SET_OPTIONS.INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
        }
    }
}