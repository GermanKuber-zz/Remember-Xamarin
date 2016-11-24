using System;
using System.Windows.Input;
using Remember.Models;
using Remember.Services;
using Remember.Services.Interfaces;
using Remember.Services.Navigation;
using XLabs;

namespace Remember.ViewModels.Remembers
{
    public class CompleteRememberViewModel : NotificationChangedBase, INavigatedViewModel<RememberModel>
    {
        private readonly IScanService _scanService;
        private readonly IBackService _backService;
        private readonly IRememberService _rememberService;
        public ICommand ReadCodeCommand => new RelayCommand(ReadCode);

        public ICommand CompleteCommand => new RelayCommand(Complete);


        public ICommand CancelCommand => new RelayCommand(Cancel);



        public ICommand UpdateCommand => new RelayCommand(Update);


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




        public CompleteRememberViewModel(IScanService scanService, IBackService backService, IRememberService rememberService)
        {
            _scanService = scanService;
            _backService = backService;
            _rememberService = rememberService;
        }
        public void SetParameter(RememberModel parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            this.Parameter = parameter;
            this.Remember = parameter;
        }


        #region  Private Methods
        private void Complete()
        {
            _rememberService.Update(this.Remember);
        }
        private void Cancel()
        {
            _backService.Back();
        }
        private void Update()
        {
            _rememberService.Update(this.Remember);
        }


        #endregion
    }
}
