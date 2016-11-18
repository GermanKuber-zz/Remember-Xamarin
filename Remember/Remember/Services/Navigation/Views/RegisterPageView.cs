using Remember.Pages.User;
using Remember.Services.Navigation.Interfaces;
using Remember.ViewModels;

namespace Remember.Services.Navigation.Views
{
    public class RegisterPageView : PageViewNavigationBase<RegisterPage, RegisterViewModel>, IRegisterPageView
    {
        public RegisterPageView(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}