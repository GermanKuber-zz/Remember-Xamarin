using Remember.Pages;
using Remember.Services.Navigation.Interfaces;
using Remember.ViewModels;

namespace Remember.Services.Navigation.Views
{
    public class MasterPageView : PageViewNavigationBase<MasterPage, MasterPageViewModel, object>, IMasterPageView
    {
        public MasterPageView(INavigationService navigationService) : base(navigationService)
        {

        }

        public override void Navigate()
        {
            this.NavigationService.SetMainPage<MasterPage>();
        }
    }
}