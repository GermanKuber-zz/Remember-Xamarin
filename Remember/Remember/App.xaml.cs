using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Remember.Data;
using Remember.Pages;
using Remember.Repositories;
using Remember.Services;
using Remember.Services.Interfaces;
using Remember.Services.Navigation;
using Remember.Services.Navigation.Interfaces;
using Remember.Services.Navigation.Views;
using Remember.ViewModels;
using Remember.ViewModels.Partials;
using Remember.ViewModels.Remembers;
using Xamarin.Forms;

namespace Remember
{

    public partial class App : Application
    {
        public static UnityContainer Container { get; set; }

        public App()
        {
            InitializeComponent();
            Register();
            var data = new DataDummy();
            data.GenerateDataDummy();
            var application = App.Container.Resolve<IApplicationService>();
            application.Start();


        }



        private void Register()
        {
            Container = new UnityContainer();

            RegisterServices();
            RegisterViews();
            RegisterRepositories();
            RegisterViewModel();


            var unityServiceLocator = new UnityServiceLocator(Container);
            ServiceLocator.SetLocatorProvider((() => unityServiceLocator));
        }

        private static void RegisterViews()
        {
            Container.RegisterType<IRememberPageView, RememberPageView>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INewRememberPageView, NewRememberPageView>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ICompleteRememberPageView, CompleteRememberPageView>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ILogOutPageView, LogOutPageView>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IRegisterPageView, RegisterPageView>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IMasterPageView, MasterPageView>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ILoginPageView, LoginPageView>(new ContainerControlledLifetimeManager());



        }

        private static void RegisterRepositories()
        {
            Container.RegisterType<ICategoryRepository, CategoryRepository>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IRememberRepository, RememberRepository>(new ContainerControlledLifetimeManager());


        }

        private static void RegisterServices()
        {
            Container.RegisterType<IDataService, DataService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ILoginService, LoginService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDialogService, DialogService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IMenuFactory, MenuFactory>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IApiService, ApiService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ICategoryService, CategoryService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IRememberService, RememberService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INetService, NetService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IScanService, ScanService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IProxyService, ProxyService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IBackService, BackService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IApplicationService, ApplicationService>(new ContainerControlledLifetimeManager());




        }

        private static void RegisterViewModel()
        {
            Container.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterType<LoginViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterType<MenuItemViewModel>(new PerResolveLifetimeManager());
            Container.RegisterType<CategoryListViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterType<RememberListViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterType<MapViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterType<NewRememberViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterType<UserHeaderViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterType<CompleteRememberViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterType<RegisterViewModel>(new ContainerControlledLifetimeManager());


        }

        #region Properties
        public static NavigationPage Navigator { get; set; } = new NavigationPage();
        public static MasterPage Master { get; set; }



        #endregion


    }
}
