using System.Windows.Forms;
using ToggleProxy.Properties;

namespace ToggleProxy
{
    public class MyApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _notifyIcon;

        public MyApplicationContext()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = RegistryHelper.GetValue() ? Resources.proxy_enabled : Resources.proxy_disabled;
            _notifyIcon.MouseDoubleClick += (sender, args) => Toggle();
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("Exit", (sender, args) => Exit()));
            _notifyIcon.ContextMenu = contextMenu;
            _notifyIcon.Visible = true;
        }

        private void Toggle()
        {
            var value = RegistryHelper.GetValue();
            value = !value;
            RegistryHelper.SetValue(value);
            NativeHelper.RefreshInternetExplorerSettings();
            _notifyIcon.Icon = RegistryHelper.GetValue() ? Resources.proxy_enabled : Resources.proxy_disabled;
        }

        private void Exit()
        {
            _notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}