using System;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Remember.Pages;
using Remember.Services.Interfaces;
using Remember.ViewModels;
using Xamarin.Forms;

namespace Remember.Services
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

        public async Task Navigate(string pageName)
        {
            this._masterPage.IsPresented = false;
            switch (pageName)
            {

                case "Configuration":
                    await this._navigationPage.PushAsync(new Configuration());
                    break;
                case "Map":
                    await this._navigationPage.PushAsync(new Map());
                    break;
                case "Remember":
                    await this._navigationPage.PushAsync(new RememberPage());
                    break;
                case "RememberList":
                    await this._navigationPage.PushAsync(new RememberList());
                    break;
                case "Logout":
                    Logout();
                    break;
                default:
                    break;

            }
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
            App.Current.MainPage = new T();

        }
        public void SetMasterPage()
        {
            var newItem = App.Container.Resolve<MasterPage>();

            App.Current.MainPage = newItem;

        }

        public void SetRequirement(MasterPage masterPage, NavigationPage navigationPage)
        {
            this._masterPage = masterPage;
            this._navigationPage = navigationPage;
        }
    }
}
