using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions;

namespace PrismTabs.Core.Mvvm
{
    public abstract class ViewModelBase : BindableBase, IDestructible, INavigationAware
    {
        public DelegateCommand<string> NavigateCommand { get; set; }

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        protected ViewModelBase()
        {

        }

        public virtual void Destroy()
        {

        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
}
