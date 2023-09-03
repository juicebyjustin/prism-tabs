using Prism.Commands;
using Prism.Regions;
using PrismTabs.Core.Mvvm;
using PrismTabs.Core.Prism;
using PrismTabs.Services.Interfaces;

namespace PrismTabs.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : ViewModelBase, IRegionManagerAware
    {
        public IRegionManager RegionManager
        {
            get => regionManager;
            set => regionManager = value;
        }

        private string _message;
        private IRegionManager regionManager;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; set; }

        private readonly IRegionManager _regionManager;

        public ViewAViewModel(IRegionManager regionManager, IMessageService messageService)
        {
            Message = messageService.GetMessage();

            _regionManager = regionManager;

            Title = "View A";
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        void Navigate(string navigationPath)
        {
            RegionManager.RequestNavigate("ChildRegion", navigationPath);
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
    }
}
