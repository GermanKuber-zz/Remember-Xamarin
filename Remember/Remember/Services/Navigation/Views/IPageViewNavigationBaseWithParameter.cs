namespace Remember.Services.Navigation.Views
{
    public interface IPageViewNavigationBaseWithParameter<in TParameter>
    {
        void Navigate(TParameter parameter);
    }
}