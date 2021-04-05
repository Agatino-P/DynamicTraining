using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;
using WpfApp.Views;

namespace WpfApp
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return new ShellWindow();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
