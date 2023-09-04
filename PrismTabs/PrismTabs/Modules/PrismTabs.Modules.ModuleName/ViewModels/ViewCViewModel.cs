using Prism.Regions;
using PrismTabs.Core.Mvvm;
using PrismTabs.Core.Prism;
using PrismTabs.Services.Interfaces;

namespace PrismTabs.Modules.ModuleName.ViewModels
{
    public class ViewCViewModel : RegionAwareViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }


        public ViewCViewModel(IRegionManager regionManager, IMessageService messageService) :
            base()
        {
            Message = messageService.GetMessage();

            Title = "ViewC";
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
    }
}
