namespace Remember.Interfaces.Cross
{
    public interface INetworkConnection
    {
        bool IsConnected { get; }
        void CheckNetworkConnection();

    }
}
