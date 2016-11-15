using System.Threading.Tasks;
using Remember.Pages;
using Remember.ViewModels;
using Xamarin.Forms;

namespace Remember.Services.Interfaces
{
    public interface INavigationService
    {
        Task Navigate(string pageName);
        Task Navigate(MenuItemViewModel viewModel);

        void SetMainPage<T>() where T : Xamarin.Forms.Page, new();

        void Navigate<T>() where T : Xamarin.Forms.Page, new();

        void SetMasterPage();
        void SetRequirement(MasterPage masterPage, NavigationPage navigationPage);
    }
}