using Remember.ViewModels;

namespace Remember.Services.Interfaces
{
    public interface IMenuFactory
    {
        MenuItemViewModel GetNewItem(string icon, string pageName, string title, Xamarin.Forms.Page page);
    }
}