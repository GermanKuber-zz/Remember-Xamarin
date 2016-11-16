namespace Remember.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new Remember.App());
            Xamarin.FormsMaps.Init("lazawWnLCeGltPQdpejM~_TxVThChleFs5RTi-xA0wA~AuPqYlwzOPCVAodBaxB7Uew5g5zbK6nRBUVZsZQ3PzeTOhHq5Z-1ia6ty9RI73Dm");
        }
    }
}
