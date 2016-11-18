using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Remember.Common;
using Remember.Pages;
using Remember.Services.Interfaces;
using Remember.Services.Navigation.Interfaces;

namespace Remember.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private readonly IDialogService _dialogService;
        private readonly IRegisterPageView _registerPageView;
        private readonly IMasterPageView _masterPageView;
        private readonly ILoginService _loginService;


        #region Properties Validation

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

        #endregion
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

        public ICommand RegisterCommand => new RelayCommand(() =>
        {
            _registerPageView.Navigate();
        });


        private async void Login()
        {
            this.IsRunning = true;
            if (string.IsNullOrEmpty(Email))
            {
                await _dialogService.ShowMessage("Error", "Debe ingresar un Usuario");
                return;
            }
            else
            {
                if (!Utilities.IsValidEmail(Email))
                {
                    await _dialogService.ShowMessage("Error", "Formato de Email Ingresado invalido");
                    return;
                }
            }
            if (string.IsNullOrEmpty(Password))
            {
                await _dialogService.ShowMessage("Error", "Debe ingresar un Password");
                return;
            }

            var user = _loginService.Login(Email, Password, IsRemembered);
            if (user.IsSuccess)
                _masterPageView.Navigate();
            else

                await _dialogService.ShowMessage("Error", "Intente nuevamente");
            this.IsRunning = false;
        }

        #endregion


        #region Constructors

        public LoginViewModel(ILoginService loginService,
            IDialogService dialogService,
            IRegisterPageView registerPageView,
            IMasterPageView masterPageView)
        {

            _loginService = loginService;
            _dialogService = dialogService;
            _registerPageView = registerPageView;
            _masterPageView = masterPageView;


            if (loginService.LogedUser != null)
            {
                if (loginService.LogedUser.IsRemember)
                    _masterPageView.Navigate();
                else
                {
                    this.Password = loginService.LogedUser.Password;
                    this.Email = loginService.LogedUser.Email;
                    this.IsRemembered = false;
                }
            }

        }

        #endregion

        #region Private Methods
        private void Validate()
        {
            if (this.IsPasswordValid && this.IsEmailValid)
                this.IsValidModel = true;
            else
                this.IsValidModel = false;
        }
        #endregion

        #region Override Methods

        public override void LoadViewModel()
        {
        }

        public override void UnLoadViewModel()
        {
        }

        #endregion

    }
}