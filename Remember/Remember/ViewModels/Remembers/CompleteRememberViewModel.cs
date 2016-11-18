using System;
using System.Windows.Input;
using Remember.Models;
using Remember.Services.Interfaces;
using XLabs;

namespace Remember.ViewModels.Remembers
{
    public class CompleteRememberViewModel : NotificationChangedBase, INavigatedViewModel<RememberModel>
    {
        private readonly IScanService _scanService;
        public ICommand ReadCodeCommand => new RelayCommand(ReadCode);

        private async void ReadCode()
        {
            var code = await _scanService.ScannerSku();
        }

        private RememberModel _remember;
        public RememberModel Remember
        {
            get { return _remember; }
            set
            {
                _remember = value;
                OnPropertyChanged();
            }
        }
        public RememberModel Parameter { get; set; }


        public CompleteRememberViewModel(IScanService scanService)
        {
            _scanService = scanService;
        }
        public void SetParameter(RememberModel parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            this.Parameter = parameter;
            this.Remember = parameter;
        }
    }
}
