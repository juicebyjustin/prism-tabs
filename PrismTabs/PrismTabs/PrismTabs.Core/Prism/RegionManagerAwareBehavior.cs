using Prism.Regions;
using PrismTabs.Core.Prism;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrismTabs.Core.Prism
{
    /// <summary>
    /// Code is pulled from PluralSight course download Mastering TabControl.
    /// 
    /// 
    /// When a view is injected into a region the view goes into the Region Adapter first. The region adapter adapts the view to the region. 
    /// Such as a TabItem is created to create a new tab item and add the view to the tab item for display in the tab control region.
    /// 
    /// Region Behaviors can apply to all regions and not be limited to a single region adapter.
    /// </summary>
    public class RegionManagerAwareBehavior : RegionBehavior
    {
        public const String BehaviorKey = "RegionManagerAwareBehavior";

        protected override void OnAttach()
        {
            Region.Views.CollectionChanged += Views_CollectionChanged;
        }

        /// <summary>
        /// Associate the scoped RegionManager to the injected View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Contains new Views to be added to the region.</param>
        void Views_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // iterate through each new View in the Region
                foreach (var item in e.NewItems)
                {
                    // start with the current regions RegionManager
                    IRegionManager regionManager = Region.RegionManager;

                    // Find the scoped RegionManager
                    // If the view was created with a scoped region manager, which in our case it is. 
                    // we need to write this code. if leave this code out it won't work as expected.
                    FrameworkElement element = item as FrameworkElement;
                    if (element != null)
                    {
                        var interfaces = element.GetType().GetInterfaces();

                        // view b returns the region manager that is used in view A....because ViewB is a child of ViewA?
                        // i don't understand how Viewb returns not null here because it has no visible RegionManagerProperty
                        IRegionManager scopedRegionManager = element.GetValue(RegionManager.RegionManagerProperty) as IRegionManager;
                        if (scopedRegionManager != null)
                        {
                            regionManager = scopedRegionManager;
                        }
                    }

                    //var t = element.GetValue(RegionManager.RegionManagerProperty);

                    InvokeOnRegionManagerAwareElement(item, x => x.RegionManager = regionManager);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    InvokeOnRegionManagerAwareElement(item, x => x.RegionManager = null);
                }
            }
        }

        /// <summary>
        /// Passing in the value we want to set.
        /// </summary>
        /// <param name="item">The value we want to set.</param>
        /// <param name="invocation"></param>
        private static void InvokeOnRegionManagerAwareElement(object item, Action<IRegionManagerAware> invocation)
        {
            // if view model
            var regionManagerAwareItem = item as IRegionManagerAware;
            if (regionManagerAwareItem != null)
            {
                invocation(regionManagerAwareItem);
            }

            // if view
            FrameworkElement frameworkElement = item as FrameworkElement;
            if (frameworkElement != null)
            {
                // get the view model
                IRegionManagerAware regionManagerAwareDataContext = frameworkElement.DataContext as IRegionManagerAware;
                if (regionManagerAwareDataContext != null)
                {
                    // If a view doesn't have a data context (view model) it will inherit the data context from the parent view.
                    // The following check is done to avoid setting the RegionManager property in the view model of the parent view by mistake. 
                    var frameworkElementParent = frameworkElement.Parent as FrameworkElement;
                    if (frameworkElementParent != null)
                    {
                        var regionManagerAwareDataContextParent = frameworkElementParent.DataContext as IRegionManagerAware;
                        if (regionManagerAwareDataContextParent != null)
                        {
                            if (regionManagerAwareDataContext == regionManagerAwareDataContextParent)
                            {
                                // If all of the previous conditions are true, it means that this view doesn't have a view model
                                // and is using the view model of its visual parent.
                                return;
                            }
                        }
                    }

                    invocation(regionManagerAwareDataContext);
                }
            }
        }
    }
}
