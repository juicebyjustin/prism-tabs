using Prism.Regions;
using PrismTabs.Core.Mvvm;
using PrismTabs.Modules.ModuleName.Model;
using PrismTabs.Services.Interfaces;
using PropertyChanged;

namespace PrismTabs.Modules.ModuleName.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ViewBViewModel : RegionViewModelBase
    {
        public ViewAModel Model { get; set; }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewBViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            Message = messageService.GetMessage();

            Title = "ViewB";
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            ViewAModel model = navigationContext.NavigationService.Region.Context as ViewAModel;
            if (model != null)
            {
                Model = model;

                Model.Data = Model.Data + "+";
            }

            //do something
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
    }
}
