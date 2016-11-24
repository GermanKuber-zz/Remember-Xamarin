using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Remember.Models;
using Remember.Services.Interfaces;
using Remember.Services.Navigation.Interfaces;

namespace Remember.ViewModels
{
    public class CategoryListViewModel : ViewModelBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILoginService _loginService;
        private readonly IRememberPageView _rememberPageView;

        #region Properties

        private string _filter;
        public string Filter
        {
            get
            {
                return _filter;

            }
            set
            {
                _filter = value;
                OnPropertyChanged();
                SearchCategory();
            }
        }
        private CategoryModel _categorySelected;
        public CategoryModel CategorySelected
        {
            get
            {
                return _categorySelected;

            }
            set
            {
                _categorySelected = value;
                OnPropertyChanged();
                SelectCategory();
            }
        }
        public ObservableCollection<CategoryModel> CategoryList { get; set; }

        public User LogedUser => _loginService.LogedUser;

        #endregion


        #region  Commands

        public ICommand SearchCategoryCommand => new RelayCommand(SearchCategory);

        public ICommand NewCategoryCommand => new RelayCommand(NewCategory);

        private void NewCategory()
        {

        }

        public ICommand SelectCategoryCommand => new RelayCommand(SelectCategory);

        private void SelectCategory()
        {
            if (this.CategorySelected != null)
                _rememberPageView.Navigate(this.CategorySelected);
        }

        private void SearchCategory()
        {
            var response = this._categoryService.GetAll(this.Filter, true);
            LoadAllRemember(response);
        }

        #endregion

        public CategoryListViewModel(ICategoryService categoryService, ILoginService loginService, IRememberPageView rememberPageView)
        {
            _categoryService = categoryService;
            _loginService = loginService;
            _rememberPageView = rememberPageView;

            var response = this._categoryService.GetAll();
            LoadAllRemember(response);
        }

        private void LoadAllRemember(List<CategoryModel> list)
        {
            if (CategoryList == null)
                CategoryList = new ObservableCollection<CategoryModel>();
            else
                CategoryList.Clear();

            if (list != null)
            {
                foreach (var rememberZone in list)
                {
                    CategoryList.Add(rememberZone);
                }
            }
        }

        public override void LoadViewModel()
        {
            var response = this._categoryService.GetAll();
            LoadAllRemember(response);
            CategorySelected = null;
        }

        public override void UnLoadViewModel()
        {
            throw new System.NotImplementedException();
        }
    }
}
