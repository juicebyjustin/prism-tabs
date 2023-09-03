using Prism.Ioc;
using Prism.Modularity;
using PrismTabs.Modules.ModuleName;
using PrismTabs.Services;
using PrismTabs.Services.Interfaces;
using PrismTabs.Views;
using System.Windows;

namespace PrismTabs
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
