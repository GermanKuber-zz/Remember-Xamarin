using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Remember.Services.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Remember.Services
{
    public class MapService : IMapService
    {
        private Map _map;
        private Map Map
        {
            get
            {
                return _map;
            }
            set
            {
                if (value != null)
                {
                    this._map = value;
                    Location().GetAwaiter();
                }

            }
        }

        public void SetMap(Map map)
        {
            if (map == null)
                throw new ArgumentNullException(nameof(map));
            this.Map = map;

        }
        private async Task Location()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var location = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            var position = new Position(location.Latitude, location.Longitude);
            _map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(0.3)));

            //If Label is not set, runtime exception
            var pin = new Pin()
            {
                Position = new Position(location.Latitude, location.Longitude),
                Label = "Some Pin!"
            };
            this.Map.Pins.Add(pin);

            var cp = new ContentPage
            {
                Content = this.Map,
            };


        }
    }
}