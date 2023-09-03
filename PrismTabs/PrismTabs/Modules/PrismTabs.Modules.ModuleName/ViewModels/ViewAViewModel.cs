using Prism.Commands;
using Prism.Regions;
using PrismTabs.Core.Mvvm;
using PrismTabs.Services.Interfaces;

namespace PrismTabs.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : ViewModelBase
    {
        private string _message;
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
            _regionManager.RequestNavigate("ChildRegion", navigationPath);
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
    }
}
