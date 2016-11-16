using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Remember.Models;
using Remember.Services;
using Remember.Services.Interfaces;
using Remember.Services.Navigation.Interfaces;


namespace Remember.ViewModels
{
    public class RememberListViewModel : NotificationChangedBase, INavigatedViewModel<CategoryModel>
    {
        private readonly ILoginService _loginService;
        private readonly IRememberService _rememberService;
        private readonly INewRememberPageView _newRememberPageView;

        public ICommand NewRememberCommand => new RelayCommand(NewRememberAction);
        #region Properties

        private string _newRemember;
        public string NewRemember
        {
            get
            {
                return _newRemember;
            }
            set
            {
                _newRemember = value;
                OnPropertyChanged();
                SearchRemember();
            }
        }

        private void NewRememberAction()
        {
            var remember = this._rememberService.GetByExactName(this.Parameter, this.NewRemember);

            if (remember == null)
                _newRememberPageView.Navigate(this.Parameter);
            //else
            //    //TODO: Si existe el remember debe de editarse el existente
        }

        private RememberModel _rememberModel;
        public RememberModel RememberSelected
        {
            get
            {
                return _rememberModel;

            }
            set
            {
                _rememberModel = value;
                OnPropertyChanged();

            }
        }
        public ObservableCollection<RememberModel> Remembers { get; set; }

        public User LogedUser => _loginService.LogedUser;

        #endregion

        private CategoryModel _parameter;
        public CategoryModel Parameter
        {
            get { return _parameter; }
            set
            {
                _parameter = value;
                OnPropertyChanged();
            }
        }
        public void SetParameter(CategoryModel parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            this.Parameter = parameter;
            this.NewRemember = string.Empty;
            SetRemembers(parameter.Remembers);
        }

        private void SetRemembers(List<RememberModel> parameter)
        {

            if (parameter != null)
            {
                if (Remembers == null)
                    Remembers = new ObservableCollection<RememberModel>();
                else
                    Remembers.Clear();
                foreach (var parameterRemember in parameter)
                {
                    Remembers.Add(parameterRemember);
                }
            }
            else
            {
                if (Remembers == null)
                    Remembers = new ObservableCollection<RememberModel>();
                else
                    Remembers.Clear();
            }
        }

        public RememberListViewModel(ILoginService loginService, IRememberService rememberService, INewRememberPageView newRememberPageView)
        {
            _loginService = loginService;
            _rememberService = rememberService;
            _newRememberPageView = newRememberPageView;
        }

        private void SearchRemember()
        {
            var list = this._rememberService.GetAll(this.Parameter, this.NewRemember, true);
            SetRemembers(list);
        }

    }

    public interface INavigatedViewModel<T>
    {
        T Parameter { get; set; }
        void SetParameter(T parameter);
    }
}
