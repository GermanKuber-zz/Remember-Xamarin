using System.Threading.Tasks;
using Xamarin.Forms;

namespace Remember.Pages
{
    public partial class Map : ContentPage
    {
        public Map()
        {
            InitializeComponent();

        }

        private async Task Location()
        {
            //var locator = CrossGeolocator.Current;
            //locator.DesiredAccuracy = 50;
            //var location = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            //var position = new Position(location.Latitude, location.Longitude);
            //MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(0.3)));

        }
    }
}
