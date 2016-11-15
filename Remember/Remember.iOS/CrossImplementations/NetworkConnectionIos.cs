using Remember.Interfaces.Cross;
using Xamarin.Forms;

[assembly: Dependency(typeof(Remember.iOS.CrossImplementations.NetworkConnectionIos))]
namespace Remember.iOS.CrossImplementations
{
    public class NetworkConnectionIos : INetworkConnection
    {
        public bool IsConnected { get; set; }
        public void CheckNetworkConnection()
        {
            IsConnected = true;
        }
    }
}