﻿using Prism.Regions;
using PrismTabs.Core.Mvvm;
using PrismTabs.Services.Interfaces;

namespace PrismTabs.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            Message = messageService.GetMessage();

            Title = "ViewA";
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
    }
}
