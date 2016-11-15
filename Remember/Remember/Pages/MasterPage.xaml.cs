using Remember.Services.Interfaces;
using Xamarin.Forms;

namespace Remember.Pages
{
    public partial class MasterPage : MasterDetailPage
    {
        private readonly INavigationService _navigationService;

        public MasterPage(INavigationService navigationService)
        {
            InitializeComponent();
            _navigationService = navigationService;
        }

        public MasterPage()
        {

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _navigationService.SetRequirement(this, Navigator);
        }
    }
}
