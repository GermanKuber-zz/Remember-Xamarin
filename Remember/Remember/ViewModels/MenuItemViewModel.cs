using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Remember.Services;

namespace Remember.ViewModels
{
    public class MenuItemViewModel
    {

        #region Attributes

        private readonly NavigationService _navigationService;


        public MenuItemViewModel()
        {
            this._navigationService = new NavigationService();
        }

        #endregion
        #region Properties
        public string Title { get; set; }
        public string Icon { get; set; }
        public string PageName { get; set; }
        #endregion





        #region Commands
        public ICommand NavigationCommand => new RelayCommand(Navigate);

        private async void Navigate()
        {
            await _navigationService.Navigate(PageName);
        }

        #endregion
    }
}
