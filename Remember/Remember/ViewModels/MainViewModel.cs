using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remember.ViewModels
{
    public class MainViewModel
    {
        #region Properties

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public LoginViewModel LoginViewModel { get; set; }
        #endregion

        #region Constructors

        public MainViewModel()
        {
            this.LoginViewModel = new LoginViewModel();
            LoadMenu();
        }

        #endregion

        #region Private Methods
        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel
                {
                    Icon = "map.png",
                    PageName = "Map",
                    Title = "Map"
                },
                new MenuItemViewModel
                {
                    Icon = "configuracion.png",
                    PageName = "Configuration",
                    Title = "Configuracion"
                },
                new MenuItemViewModel
                {
                    Icon = "remember.png",
                    PageName = "Remember",
                    Title = "Remember"
                },
                   new MenuItemViewModel
                {
                    Icon = "exit.png",
                    PageName = "Logout",
                    Title = "Logout"
                }
            };
        }
        #endregion
    }
}
