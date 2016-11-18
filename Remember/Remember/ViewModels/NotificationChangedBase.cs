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

        private bool _isValid;
        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                this._isValid = value;
                this.OnPropertyChanged();
            }
        }
    }
}