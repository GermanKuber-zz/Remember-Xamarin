namespace Remember.Services.Navigation.Interfaces
{
    public interface IRegisterPageView : IPageViewNavigationBase
    {

    }

    public interface IPageViewNavigationBase
    {
        void Navigate();
    }
}