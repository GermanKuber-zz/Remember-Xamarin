using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Remember.Services.Interfaces;

namespace Remember.ViewModels
{
    public class LoginViewModel : NotificationChangedBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly ILoginService _loginService;

        #region Properties

        private string _email;
        public string Email
        {
            get
            {
                return _email;

            }
            set
            {
                this._email = value;
                this.OnPropertyChanged();
            }
        }


        public string Password { get; set; }
        public bool IsRemembered { get; set; } = true;
        private bool _IsRunning = false;
        public bool IsRunning
        {
            get
            {
                return _IsRunning;

            }
            set
            {
                this._IsRunning = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region Commands
        public ICommand LoginCommand => new RelayCommand(Login);



        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await _dialogService.ShowMessage("Error", "Debe ingresar un Usuario");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await _dialogService.ShowMessage("Error", "Debe ingresar un Password");
                return;
            }
            this.IsRunning = true;
            var user = _loginService.Login(Email, Password, IsRemembered);
            if (user.IsSuccess)
                _navigationService.SetMasterPage();
            else
                await _dialogService.ShowMessage("Error", "Intente nuevamente");
            this.IsRunning = false;
        }

        #endregion


        #region Constructors

        public LoginViewModel(INavigationService navigationService,
            ILoginService loginService,
            IDialogService dialogService)
        {
            _navigationService = navigationService;
            _loginService = loginService;
            _dialogService = dialogService;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}