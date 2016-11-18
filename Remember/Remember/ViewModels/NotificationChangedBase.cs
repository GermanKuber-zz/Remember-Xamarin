using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Remember.ViewModels
{
    public class NotificationChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public NotificationChangedBase()
        {

        }
        private bool _isValidModel = false;
        public bool IsValidModel
        {
            get
            {
                return _isValidModel;
            }
            set
            {
                this._isValidModel = value;
                this.OnPropertyChanged();
            }
        }
    }
}