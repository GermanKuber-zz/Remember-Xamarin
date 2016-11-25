using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Remember.Data;
using Remember.Models;
using Remember.Services.Interfaces;
using Remember.Services.Navigation.Interfaces;


namespace Remember.ViewModels
{
    public class RememberListViewModel : ViewModelBase, INavigatedViewModel<CategoryData>
    {
        private readonly ILoginService _loginService;
        private readonly IRememberService _rememberService;
        private readonly INewRememberPageView _newRememberPageView;
        private readonly ICompleteRememberPageView _completeRememberPageView;

        public ICommand NewRememberCommand => new RelayCommand(NewRememberAction);
        public ICommand RefreshCommand => new RelayCommand(RefreshRemembers);

        public ICommand CompleteRememberCommand => new RelayCommand(CompleteRemember);

        private void CompleteRemember()
        {
            throw new NotImplementedException();
        }

        private void RefreshRemembers()
        {

        }

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
            else
                NavigateCompleteRemember(remember);

        }

        private void NavigateCompleteRemember(RememberModel remember)
        {
            _completeRememberPageView.Navigate(remember);
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
                if (_rememberModel != value)
                {
                    _rememberModel = value;
                    OnPropertyChanged();
                    if (value != null)
                        NavigateCompleteRemember(this.RememberSelected);
                }
            }
        }
        public ObservableCollection<RememberModel> Remembers { get; set; }

        public User LogedUser => _loginService.LogedUser;

        #endregion

        private CategoryData _parameter;
        public CategoryData Parameter
        {
            get { return _parameter; }
            set
            {
                _parameter = value;
                OnPropertyChanged();
            }
        }
        public void SetParameter(CategoryData parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            this.Parameter = parameter;
            this.NewRemember = string.Empty;
        }

        private void LoadAllRemembersRemembers(List<RememberModel> parameter)
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

        public RememberListViewModel(ILoginService loginService,
            IRememberService rememberService,
            INewRememberPageView newRememberPageView,
            ICompleteRememberPageView completeRememberPageView)
        {
            _loginService = loginService;
            _rememberService = rememberService;
            _newRememberPageView = newRememberPageView;
            _completeRememberPageView = completeRememberPageView;

        }

        private void SearchRemember()
        {
            var list = new List<RememberModel>();
            if (!string.IsNullOrWhiteSpace(this.NewRemember))
                list = this._rememberService.GetAll(this.Parameter, this.NewRemember, true);
            else
                list = this._rememberService.GetAllNoCompleted(this.Parameter, this.NewRemember, true);
            LoadAllRemembersRemembers(list);
        }

        public override void LoadViewModel()
        {
            var list = this._rememberService.GetAllNoCompleted(this.Parameter, this.NewRemember, true);
            //TODO Cambiar a CategoryModel
            LoadAllRemembersRemembers(list);
        }

        public override void UnLoadViewModel()
        {

        }
    }

    public interface INavigatedViewModel<T>
    {
        T Parameter { get; set; }
        void SetParameter(T parameter);
    }
}
