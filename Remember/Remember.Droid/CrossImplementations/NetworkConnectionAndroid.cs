using System;
using Remember.Interfaces.Cross;
using Xamarin.Forms;
[assembly: Dependency(typeof(Remember.Droid.CrossImplementations.NetworkConnectionAndroid))]
namespace Remember.Droid.CrossImplementations
{

    public class NetworkConnectionAndroid : INetworkConnection
    {
        public bool IsConnected { get; set; }
        public void CheckNetworkConnection()
        {
            IsConnected = true;
        }
    }
}