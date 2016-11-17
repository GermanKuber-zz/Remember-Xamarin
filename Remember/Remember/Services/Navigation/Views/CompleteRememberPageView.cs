using Microsoft.Practices.Unity;
using Remember.Models;
using Remember.Pages.Remember;
using Remember.Services.Navigation.Interfaces;
using Remember.ViewModels.Remembers;

namespace Remember.Services.Navigation.Views
{
    public class CompleteRememberPageView : ICompleteRememberPageView
    {
        private readonly INavigationService _navigationService;

        public CompleteRememberPageView(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Navigate(RememberModel parameter)
        {
            _navigationService.Navigate<CompleteRememberPage>();

            var context = App.Container.Resolve<CompleteRememberViewModel>();
            context.SetParameter(parameter);

        }
    }
}