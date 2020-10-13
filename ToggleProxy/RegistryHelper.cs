using Microsoft.Win32;

namespace ToggleProxy
{
    public static class RegistryHelper
    {
        private const string Key = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings";

        public static bool ProxyEnable
        {
            get
            {
                var value = Registry.GetValue(Key, "ProxyEnable", string.Empty);
                return value.ToString() == "1";
            }

            set
            {
                var regValue = value ? 1 : 0;
                Registry.SetValue(Key, "ProxyEnable", regValue, RegistryValueKind.DWord);
            }
        }

        public static string ProxyServer
        {
            get
            {
                var value = Registry.GetValue(Key, "ProxyServer", string.Empty);
                return value.ToString();
            }

            set
            {
                Registry.SetValue(Key, "ProxyServer", value, RegistryValueKind.String);
            }
        }

        public static string ProxyOverride
        {
            get
            {
                var value = Registry.GetValue(Key, "ProxyOverride", string.Empty);
                return value.ToString();
            }

            set
            {
                Registry.SetValue(Key, "ProxyOverride", value, RegistryValueKind.String);
            }
        }
    }
}