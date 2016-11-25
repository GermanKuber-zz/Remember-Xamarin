using System.ComponentModel;
using Microsoft.Practices.Unity;
using Remember.Services.Interfaces;
using Xamarin.Forms;

namespace Remember.Pages.Categories
{
    public partial class NewCategoryPage : ContentPage
    {
        public NewCategoryPage()
        {
            InitializeComponent();
            var mapService = App.Container.Resolve<IMapService>();
            mapService.SetMap(this.MyMap);
        }

        private void MyMap_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }
    }
}
