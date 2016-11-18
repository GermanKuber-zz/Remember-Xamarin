using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Remember.Models;
using Remember.Services.Interfaces;
using Remember.Services.Navigation;
using Remember.Services.Navigation.Interfaces;

namespace Remember.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {

        private readonly IDialogService _dialogService;
        private readonly IBackService _backService;
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
                Validate();
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
                Validate();
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
                Validate();
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
                this._backService.Back();
            }
            else
            {
                _dialogService.ShowMessage("Error", response.Message);
            }

        }



        #endregion


        #region Constructors

        public RegisterViewModel(IBackService backService,
            ILoginService loginService,
            IDialogService dialogService)
        {
            _backService = backService;
            _loginService = loginService;
            _dialogService = dialogService;



        }

        #endregion

        #region Private Methods

        private void Validate()
        {
            if (this.IsEmailValid && this.IsNameValid && this.IsPasswordValid)
                this.IsValidModel = true;
            else
                this.IsValidModel = false;
        }

        #endregion

        public override void LoadViewModel()
        {
            this.Email = string.Empty;
            this.Name = string.Empty;
            this.Password = string.Empty;
            this.RePassword = string.Empty;
        }

        public override void UnLoadViewModel()
        {
            throw new System.NotImplementedException();
        }
    }
}