using System;
using System.IO;

namespace ToggleProxy
{
    internal static class SettingsHelper
    {
        private static readonly string SettingsPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MadCowDevelopment",
                "ToggleProxy");

        private static readonly string SettingsFile = Path.Combine(SettingsPath, "settings.cfg");

        public static string ProxyServer
        {
            get
            {
                if (!File.Exists(SettingsFile))
                {
                    ProxyServer = RegistryHelper.ProxyServer;
                }

                return File.ReadAllText(SettingsFile);
            }

            set
            {
                Directory.CreateDirectory(SettingsPath);
                File.WriteAllText(SettingsFile, value);
            }
        }
    }
}