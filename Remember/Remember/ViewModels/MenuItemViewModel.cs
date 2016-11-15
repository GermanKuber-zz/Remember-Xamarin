using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Remember.Services.Interfaces;

namespace Remember.ViewModels
{
    public class MenuItemViewModel
    {

        #region Attributes

        private readonly INavigationService _navigationService;


        public MenuItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        #endregion
        #region Properties
        public string Title { get; set; }
        public string Icon { get; set; }
        public string PageName { get; set; }
        public Xamarin.Forms.Page Page { get; set; }
        #endregion





        #region Commands
        public ICommand NavigationCommand => new RelayCommand(Navigate);

        private async void Navigate()
        {
            await _navigationService.Navigate(this);
        }

        #endregion
    }
}
