using Remember.Models;
using Remember.Services.Interfaces;

namespace Remember.ViewModels.Partials
{
    public class UserHeaderViewModel
    {
        private readonly ILoginService _loginService;
        public User LogedUser => _loginService.LogedUser;

        public UserHeaderViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }
    }
}
