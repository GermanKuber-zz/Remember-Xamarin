using Microsoft.Practices.Unity;

namespace Remember.ViewModels
{
    public class LocatorViewModel
    {
        public LoginViewModel LoginViewModel => App.Container.Resolve<LoginViewModel>();
        public MainViewModel MainViewModel => App.Container.Resolve<MainViewModel>();
        public CategoryListViewModel RememberZoneListViewModel => App.Container.Resolve<CategoryListViewModel>();

    }
}
