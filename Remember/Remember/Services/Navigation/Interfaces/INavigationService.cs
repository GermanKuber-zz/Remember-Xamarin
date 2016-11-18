using System.Threading.Tasks;
using Remember.Pages;
using Remember.ViewModels;
using Xamarin.Forms;

namespace Remember.Services.Navigation.Interfaces
{
    public interface INavigationService
    {

        Task Navigate(MenuItemViewModel viewModel);
        Task Back();

        void SetMainPage<T>() where T : Page, new();

        void Navigate<T>() where T : Page, new();
        void SetRequirement(MasterPage masterPage, NavigationPage navigationPage);
    }
}