using Microsoft.Practices.Unity;
using Remember.ViewModels.Partials;
using Remember.ViewModels.Remembers;

namespace Remember.ViewModels
{
    public class LocatorViewModel
    {
        public LoginViewModel LoginViewModel => App.Container.Resolve<LoginViewModel>();
        public MainViewModel MainViewModel => App.Container.Resolve<MainViewModel>();
        public CategoryListViewModel CategoryListViewModel => App.Container.Resolve<CategoryListViewModel>();
        public RememberListViewModel RememberListViewModel => App.Container.Resolve<RememberListViewModel>();
        public MapViewModel MapViewModel => App.Container.Resolve<MapViewModel>();
        public UserHeaderViewModel UserHeaderViewModel => App.Container.Resolve<UserHeaderViewModel>();
        public NewRememberViewModel NewRememberViewModel => App.Container.Resolve<NewRememberViewModel>();



    }
}
