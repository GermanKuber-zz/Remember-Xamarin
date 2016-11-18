using System.Collections.ObjectModel;
using Remember.Pages;
using Remember.Services.Interfaces;

namespace Remember.ViewModels
{
    public class MainViewModel
    {
        private readonly IMenuFactory _menuFactory;

        #region Properties

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }


        #endregion

        #region Constructors

        public MainViewModel(IMenuFactory menuFactory)
        {
            _menuFactory = menuFactory;


            LoadMenu();
        }



        #endregion

        #region Private Methods



        private void LoadMenu()
        {

            Menu = new ObservableCollection<MenuItemViewModel>
            {
                _menuFactory.GetNewItem("map.png","Map","Map", new Map()),
                _menuFactory.GetNewItem("configuracion.png","Configuration","Configuracion", new Configuration()),
                _menuFactory.GetNewItem("remember.png","Remember","Remember", new RememberPage()),
                _menuFactory.GetNewItem("remember.png","Categorias","Categorias", new CategoriasList()),
                _menuFactory.GetNewItem( "exit.png","Logout","Logout", null)
            };
        }
        #endregion
    }
}
