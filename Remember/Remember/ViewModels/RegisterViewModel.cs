using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Remember.Models;
using Remember.Services.Interfaces;
using Remember.Services.Navigation.Interfaces;

namespace Remember.ViewModels
{
    public class RegisterViewModel : NotificationChangedBase
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

        private string _password;
        public string Password
        {
            get
            {
                return _password;

            }
            set
            {
                this._password = value;
                this.OnPropertyChanged();
            }
        }
        private string _rePassword;
        public string RePassword
        {
            get
            {
                return _rePassword;

            }
            set
            {
                this._rePassword = value;
                this.OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;

            }
            set
            {
                this._name = value;
                this.OnPropertyChanged();
            }
        }

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

        private bool _isPasswordValid;
        public bool IsPasswordValid
        {
            get { return _isPasswordValid; }
            set
            {
                this._isPasswordValid = value;
                this.OnPropertyChanged();
            }
        }

        private bool _isEmailValid;
        public bool IsEmailValid
        {
            get { return _isEmailValid; }
            set
            {
                this._isEmailValid = value;
                this.OnPropertyChanged();
            }
        }
        private bool _isNameValid;
        public bool IsNameValid
        {
            get { return _isNameValid; }
            set
            {
                this._isNameValid = value;
                this.OnPropertyChanged();
            }
        }


        #endregion

        #region Commands
        public ICommand RegisterCommand => new RelayCommand(Register);

        private void Register()
        {
            var newUser = new User
            {
                Email = Email,
                Password = Password,
                FirstName = Name
            };
            var response = _loginService.Register(newUser);
            if (response.IsSuccess)
            {
                _dialogService.ShowMessage("Bienvenido", "Usuario Creado, ahora puede loguearse!");
                this._navigationService.Back();
            }
            else
            {
                _dialogService.ShowMessage("Error", response.Message);
            }

        }


        private async void Login()
        {
            //if (string.IsNullOrEmpty(Email))
            //{
            //    await _dialogService.ShowMessage("Error", "Debe ingresar un Usuario");
            //    return;
            //}
            //else
            //{
            //    if (!Utilities.IsValidEmail(Email))
            //    {
            //        await _dialogService.ShowMessage("Error", "Formato de Email Ingresado invalido");
            //        return;
            //    }
            //}
            //if (string.IsNullOrEmpty(Password))
            //{
            //    await _dialogService.ShowMessage("Error", "Debe ingresar un Password");
            //    return;
            //}
            //this.IsRunning = true;
            //var user = _loginService.Login(Email, Password, IsRemembered);
            //if (user.IsSuccess)
            //    _navigationService.SetMasterPage();
            //else

            //    await _dialogService.ShowMessage("Error", "Intente nuevamente");
            //this.IsRunning = false;
        }

        #endregion


        #region Constructors

        public RegisterViewModel(INavigationService navigationService,
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