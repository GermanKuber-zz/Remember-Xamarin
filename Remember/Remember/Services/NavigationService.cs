using System.Threading.Tasks;
using Remember.Pages;

namespace Remember.Services
{
    public class NavigationService
    {
        public async Task Navigate(string pageName)
        {
            App.Master.IsPresented = false;
            switch (pageName)
            {

                case "Configuration":
                    await App.Navigator.PushAsync(new Configuration());
                    break;


                case "Map":
                    await App.Navigator.PushAsync(new Map());
                    break;
                case "Remember":
                    await App.Navigator.PushAsync(new RememberPage());
                    break;
                default:
                    break;

            }
        }
    }
}
