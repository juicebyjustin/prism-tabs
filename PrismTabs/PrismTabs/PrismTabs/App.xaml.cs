using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismTabs.Modules.ModuleName;
using PrismTabs.Services;
using PrismTabs.Services.Interfaces;
using PrismTabs.Views;
using System.Windows;
using TabControlRegion.Core.Prism;

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

            containerRegistry.RegisterSingleton<IRegionNavigationContentLoader, ScopedRegionNavigationContentLoader>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
