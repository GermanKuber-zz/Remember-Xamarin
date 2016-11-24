using Remember.Services.Interfaces;
using Remember.Services.Navigation.Interfaces;
using Remember.Services.Navigation.Views;

namespace Remember.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly ILoginService _loginService;
        private readonly IMasterPageView _masterPageView;
        private readonly ILoginPageView _loginPageView;

        public ApplicationService(ILoginService loginService,
            IMasterPageView masterPageView,
            ILoginPageView loginPageView)
        {
            _loginService = loginService;
            _masterPageView = masterPageView;
            _loginPageView = loginPageView;
        }

        public void Start()
        {
            if (_loginService.LogedUser != null)
            {
                if (_loginService.LogedUser.IsRemember)
                    _masterPageView.Navigate();
                else
                {
                    _loginPageView.Navigate();
                }
            }
            else
            {
                _loginPageView.Navigate();
            }
        }
    }
}