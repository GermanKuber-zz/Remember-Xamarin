using Microsoft.Practices.Unity;
using Remember.Services.Interfaces;
using Remember.ViewModels;

namespace Remember.Services
{
    public class MenuFactory : IMenuFactory
    {
        public MenuItemViewModel GetNewItem(string icon, string pageName, string title, Xamarin.Forms.Page page)
        {
            var newItem = App.Container.Resolve<MenuItemViewModel>();
            newItem.Icon = icon;
            newItem.PageName = pageName;
            newItem.Title = title;
            newItem.Page = page;

            return newItem;
        }


    }
}
