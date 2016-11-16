using System.Windows.Forms;
using ToggleProxy.Properties;

namespace ToggleProxy
{
    public class MyApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _notifyIcon;

        public MyApplicationContext()
        {
            if (!string.IsNullOrEmpty(RegistryHelper.ProxyServer))
                SettingsHelper.ProxyServer = RegistryHelper.ProxyServer;

            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = RegistryHelper.ProxyEnable ? Resources.proxy_enabled : Resources.proxy_disabled;
            _notifyIcon.MouseDoubleClick += (sender, args) => Toggle();
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("Toggle", (sender, args) => Toggle()));
            contextMenu.MenuItems.Add(new MenuItem("Exit", (sender, args) => Exit()));
            _notifyIcon.ContextMenu = contextMenu;
            _notifyIcon.Visible = true;
        }

        private void Toggle()
        {
            var value = RegistryHelper.ProxyEnable;
            value = !value;
            RegistryHelper.ProxyEnable = value;
            if(string.IsNullOrEmpty(RegistryHelper.ProxyServer)) RegistryHelper.ProxyServer = SettingsHelper.ProxyServer;
            NativeHelper.RefreshInternetExplorerSettings();
            _notifyIcon.Icon = RegistryHelper.ProxyEnable ? Resources.proxy_enabled : Resources.proxy_disabled;
        }

        private void Exit()
        {
            _notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}