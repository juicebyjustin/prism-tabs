using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions;
using PrismTabs.Core.Prism;

namespace PrismTabs.Core.Mvvm
{
    public abstract class RegionAwareViewModelBase : ViewModelBase, IRegionManagerAware
    {
        protected RegionAwareViewModelBase()
        {

        }

        public IRegionManager RegionManager { get; set; }
    }
}
