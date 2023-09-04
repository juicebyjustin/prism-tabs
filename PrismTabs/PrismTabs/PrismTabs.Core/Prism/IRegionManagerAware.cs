using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismTabs.Core.Prism
{
    /// <summary>
    /// Must be applied to every class which can take part in subregions/childregions.
    /// 
    /// This could even be applied to a RegionAwareViewModelBase.
    /// </summary>
    public interface IRegionManagerAware
    {
        IRegionManager RegionManager { get; set; }
    }
}
