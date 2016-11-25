namespace Remember.Services.Navigation.Interfaces
{
    public interface IPageViewNavigationBaseWithParameter<in TParameter>
    {
        void Navigate(TParameter parameter);
    }
}