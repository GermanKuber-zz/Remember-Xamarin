using Remember.Data;
using Remember.Pages.Categories;
using Remember.Services.Navigation.Interfaces;
using Remember.ViewModels.Categories;

namespace Remember.Services.Navigation.Views
{
    public class NewCategoryPageView : PageViewNavigationBaseWithParameter<NewCategoryPage, NewCategoryViewModel, object>, INewCategoryPageView
    {
        public NewCategoryPageView(INavigationService navigationService) : base(navigationService)
        {
        }


    }
}