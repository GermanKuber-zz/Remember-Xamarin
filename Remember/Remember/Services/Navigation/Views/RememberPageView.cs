using Remember.Models;
using Remember.Pages;
using Remember.Services.Navigation.Interfaces;
using Remember.ViewModels;

namespace Remember.Services.Navigation.Views
{


    public class RememberPageView : PageViewNavigationBaseWithParameter<RememberList, RememberListViewModel, CategoryModel>, IRememberPageView
    {
        public RememberPageView(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
