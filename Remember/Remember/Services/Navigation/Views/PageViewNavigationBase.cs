using Microsoft.Practices.Unity;
using Remember.Services.Navigation.Interfaces;
using Remember.ViewModels;
using Xamarin.Forms;

namespace Remember.Services.Navigation.Views
{
    public class PageViewNavigationBase<TPage, TViewModel> : IPageViewNavigationBase where TPage : Page, new()
        where TViewModel : IViewModelBase
    {
        protected readonly INavigationService NavigationService;

        public PageViewNavigationBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        public virtual void Navigate()
        {
            NavigationService.Navigate<TPage>();
            var context = App.Container.Resolve<TViewModel>();
            context.LoadViewModel();

        }
    }

}