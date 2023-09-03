using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismTabs.Core.Mvvm;

namespace PrismTabs.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate("ContentRegion", navigationPath);
        }
    }
}
