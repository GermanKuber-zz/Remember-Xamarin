using Remember.Interfaces.Cross;
using Remember.Services.Interfaces;
using Xamarin.Forms;

namespace Remember.Services
{
    public class NetService : INetService
    {
        public bool IsConnected()
        {
            var netWorkConnection = DependencyService.Get<INetworkConnection>();
            if (netWorkConnection != null)
            {

                netWorkConnection.CheckNetworkConnection();
                return netWorkConnection.IsConnected;
            }
            else
            {
                return true;
            }
        }
    }
}
