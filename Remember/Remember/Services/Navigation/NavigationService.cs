using System.Threading.Tasks;
using Remember.Pages;
using Remember.Services.Interfaces;
using Remember.Services.Navigation.Interfaces;
using Remember.ViewModels;
using Xamarin.Forms;

namespace Remember.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly ILoginService _loginService;
        private MasterPage _masterPage;
        private NavigationPage _navigationPage;


        public NavigationService(ILoginService loginService)
        {
            _loginService = loginService;
        }



        public async Task Navigate(MenuItemViewModel viewModel)
        {
            this._masterPage.IsPresented = false;
            if (viewModel.PageName == "Logout")
                Logout();
            else
            {
                await this._navigationPage.PushAsync(viewModel.Page);
            }
        }
        public async Task Back()
        {

            await this._navigationPage.PopAsync();

        }

        public void Navigate<T>() where T : Xamarin.Forms.Page, new()
        {
            this._navigationPage.PushAsync(new T());
        }

        private void Logout()
        {
            var response = _loginService.LogOut();
            if (response.IsSuccess)
                App.Current.MainPage = new LoginPage();

            //Todo: Error

        }

        public void SetMainPage<T>() where T : Xamarin.Forms.Page, new()
        {
            if (!setMainPage)
            {
                _navigationPage = new NavigationPage(new T());

                App.Current.MainPage = _navigationPage;
                setMainPage = true;
            }
            else
            {
                this.Navigate<T>();
            }


        }


        private bool setMainPage = false;

        public void SetRequirement(MasterPage masterPage, NavigationPage navigationPage)
        {
            this._masterPage = masterPage;
            this._navigationPage = navigationPage;
        }
    }
}
