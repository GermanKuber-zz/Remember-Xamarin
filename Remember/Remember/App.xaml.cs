using Remember.Pages;
using Xamarin.Forms;

namespace Remember
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MasterPage();
        }

        #region Properties
        public static NavigationPage Navigator { get; set; }
        public static MasterPage Master { get; set; }
        #endregion
    }
}
