using Remember.Pages;
using Remember.Services.Interfaces;
using Remember.Services.Navigation.Interfaces;

namespace Remember.Services.Navigation.Views
{
    public class LogOutPageView : ILogOutPageView
    {
        private readonly INavigationService _navigationService;
        private readonly ILoginService _loginService;

        public LogOutPageView(INavigationService navigationService, ILoginService loginService)
        {
            _navigationService = navigationService;
            _loginService = loginService;
        }

        public void Navigate()
        {
            if (_loginService.LogOut().IsSuccess)
                _navigationService.Navigate<LoginPage>();


        }
    }
}