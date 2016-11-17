using Remember.Pages.User;
using Remember.Services.Navigation.Interfaces;

namespace Remember.Services.Navigation.Views
{
    public class RegisterPageView : IRegisterPageView
    {
        private readonly INavigationService _navigationService;

        public RegisterPageView(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Navigate()
        {
            _navigationService.Navigate<RegisterPage>();


        }
    }
}