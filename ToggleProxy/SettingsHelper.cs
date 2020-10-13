using System;
using System.IO;

namespace ToggleProxy
{
    internal static class SettingsHelper
    {
        private static readonly string SettingsPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MadCowDevelopment",
                "ToggleProxy");

        private static readonly string ProxyServerFile = Path.Combine(SettingsPath, "proxyserver.cfg");
        private static readonly string ProxyOverrideFile = Path.Combine(SettingsPath, "proxyoverride.cfg");

        public static string ProxyServer
        {
            get
            {
                if (!File.Exists(ProxyServerFile))
                {
                    ProxyServer = RegistryHelper.ProxyServer;
                }

                return File.ReadAllText(ProxyServerFile);
            }

            set
            {
                Directory.CreateDirectory(SettingsPath);
                File.WriteAllText(ProxyServerFile, value);
            }
        }

        public static string ProxyOverride
        {
            get
            {
                if (!File.Exists(ProxyOverrideFile))
                {
                    ProxyOverride = RegistryHelper.ProxyOverride;
                }

                return File.ReadAllText(ProxyOverrideFile);
            }

            set
            {
                Directory.CreateDirectory(SettingsPath);
                File.WriteAllText(ProxyOverrideFile, value);
            }
        }
    }
}