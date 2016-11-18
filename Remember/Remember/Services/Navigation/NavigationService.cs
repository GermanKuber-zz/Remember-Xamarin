using System;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
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
            _masterPage.IsPresented = false;
            if (viewModel.PageName == "Logout")
                Logout();
            else
            {
                await _navigationPage.PushAsync(viewModel.Page);
            }
        }
        public async Task Back()
        {

            await _navigationPage.PopAsync();

        }

        public void Navigate<T>() where T : Page, new()
        {
            _navigationPage.PushAsync(new T());
        }

        private void Logout()
        {
            var response = _loginService.LogOut();
            if (response.IsSuccess)
                Application.Current.MainPage = new LoginPage();

            //Todo: Error

        }

        public void SetMainPage<T>() where T : Page, new()
        {
            Type listType = typeof(T);
            if (listType != typeof(MasterPage))
            {
                _navigationPage = new NavigationPage(new T());

                Application.Current.MainPage = _navigationPage;

            }
            else
            {
                Application.Current.MainPage = App.Container.Resolve<T>();
            }


        }


        private bool setMainPage = false;

        public void SetRequirement(MasterPage masterPage, NavigationPage navigationPage)
        {
            _masterPage = masterPage;
            _navigationPage = navigationPage;
        }
    }
}
