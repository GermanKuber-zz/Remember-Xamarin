using Remember.Pages;
using Remember.Services;
using Xamarin.Forms;

namespace Remember
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DataService = new DataService();

            var user = DataService.GetUser();
            if (user != null && user.IsRemember)
                MainPage = new MasterPage();
            else
                MainPage = new LoginPage();

        }

        #region Properties
        public static NavigationPage Navigator { get; set; }
        public static MasterPage Master { get; set; }

        public static DataService DataService { get; set; }
        #endregion
    }
}
