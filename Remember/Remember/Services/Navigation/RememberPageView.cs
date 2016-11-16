using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Remember.Models;
using Remember.Pages;
using Remember.Services.Interfaces;
using Remember.Services.Navigation.Interfaces;
using Remember.ViewModels;

namespace Remember.Services.Navigation
{
    public class RememberPageView : IRememberPageView
    {
        private readonly INavigationService _navigationService;

        public RememberPageView(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Navigate(CategoryModel parameter)
        {
            _navigationService.Navigate<RememberList>();

            var context = App.Container.Resolve<RememberListViewModel>();
            context.SetParameter(parameter);

        }
    }
}
