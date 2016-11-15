using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Remember.Services;

namespace Remember.ViewModels
{
    public class LoginViewModel : NotificationChangedBase
    {
        private readonly NavigationService _navigationService;
        private readonly DialogService _dialogService;
        private readonly LoginService _loginService;
        private readonly DataService _dataService;
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
            if ((await _loginService.Login(Email, Password, IsRemembered)).IsSuccess)
                _navigationService.SetMainPage();
            else
                await _dialogService.ShowMessage("Error", "Intente nuevamente");
        }

        #endregion


        #region Constructors

        public LoginViewModel()
        {
            _navigationService = new NavigationService();
            _dialogService = new DialogService();
            _loginService = new LoginService();
            _dataService = new DataService();
        }

        #endregion

        #region Private Methods

        #endregion
    }
}