using Microsoft.Practices.Unity;
using Remember.Models;
using Remember.Pages.Remember;
using Remember.Services.Interfaces;
using Remember.Services.Navigation.Interfaces;
using Remember.ViewModels.Remembers;

namespace Remember.Services.Navigation
{
    public class NewRememberPageView : INewRememberPageView
    {
        private readonly INavigationService _navigationService;

        public NewRememberPageView(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Navigate(CategoryModel parameter)
        {
            _navigationService.Navigate<NewRememberPage>();
            var context = App.Container.Resolve<NewRememberViewModel>();
            context.SetParameter(parameter);

        }
    }
}