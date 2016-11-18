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

    public class PageViewNavigationBaseWithParameter<TPage, TViewModel, TParameter> : IPageViewNavigationBaseWithParameter<TParameter> where TPage : Page, new()
    where TViewModel : IViewModelBase, INavigatedViewModel<TParameter>

    {
        protected readonly INavigationService NavigationService;

        public PageViewNavigationBaseWithParameter(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public void Navigate(TParameter parameter)
        {
            NavigationService.Navigate<TPage>();
            var context = App.Container.Resolve<TViewModel>();
            context.SetParameter(parameter);
            context.LoadViewModel();
        }
    }
}