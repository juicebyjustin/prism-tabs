using Prism.Regions;
using PrismTabs.Core.Mvvm;
using PrismTabs.Core.Prism;
using PrismTabs.Modules.ModuleName.Model;
using PrismTabs.Services.Interfaces;
using PropertyChanged;

namespace PrismTabs.Modules.ModuleName.ViewModels
{
    /// <summary>
    /// <see cref="IRegionManagerAware"/> must be on every view model
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class ViewBViewModel : ViewModelBase, IRegionManagerAware
    {
        private readonly IRegionManager _regionManager;

        public ViewAModel Model { get; set; }

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

        public ViewBViewModel(IRegionManager regionManager, IMessageService messageService) :
            base()
        {
            _regionManager = regionManager;
            Message = messageService.GetMessage();

            Title = "ViewB";
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            ViewAModel model = navigationContext.NavigationService.Region.Context as ViewAModel;

           // var regions = RegionManager.Regions;

            if (model != null)
            {
                Model = model;

                Model.Data = Model.Data + "+";
            }

            // proves that we can navigate a view into this current views region.
            // RegionManager.RequestNavigate("ChildRegion", "ViewA");

            //do something
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
    }
}
