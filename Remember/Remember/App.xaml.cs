﻿using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Remember.Pages;
using Remember.Repositories;
using Remember.Services;
using Remember.Services.Interfaces;
using Remember.Services.Navigation;
using Remember.Services.Navigation.Interfaces;
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
            var loginService = App.Container.Resolve<ILoginService>();
            var navigate = App.Container.Resolve<INavigationService>();



            if (loginService.LogedUser != null && loginService.LogedUser.IsRemember)
            {
                navigate.SetMasterPage();
            }
            else
                navigate.SetMainPage<LoginPage>();



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

        }

        private static void RegisterRepositories()
        {
            Container.RegisterType<ICategoryRepository, MockCategoryRepository>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IRememberRepository, MockRememberRepository>(new ContainerControlledLifetimeManager());
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
        }

        #region Properties
        public static NavigationPage Navigator { get; set; } = new NavigationPage();
        public static MasterPage Master { get; set; }



        #endregion


    }
}
