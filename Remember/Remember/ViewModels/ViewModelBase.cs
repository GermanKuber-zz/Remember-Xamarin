namespace Remember.ViewModels
{
    public abstract class ViewModelBase : NotificationChangedBase, IViewModelBase
    {
        public abstract void LoadViewModel();
        public abstract void UnLoadViewModel();

    }
}