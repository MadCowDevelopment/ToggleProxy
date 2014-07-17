using Microsoft.Win32;

namespace ToggleProxy
{
    public static class RegistryHelper
    {
        private const string Key = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings";
        public static bool GetValue()
        {
            var value = Registry.GetValue(Key, "ProxyEnable", string.Empty);
            return value.ToString() == "1";
        }

        public static void SetValue(bool value)
        {
            var regValue = value ? 1 : 0;
            Registry.SetValue(Key, "ProxyEnable", regValue, RegistryValueKind.DWord);
        }
    }
}