using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Prism.Logging;
using Remember.Models;
using Remember.Pages;
using Remember.Services.Interfaces;
using Remember.Services.Navigation;

namespace Remember.ViewModels
{
    public class CategoryListViewModel : NotificationChangedBase
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
        public ObservableCollection<CategoryModel> CategoryModel { get; set; }

        public User LogedUser => _loginService.LogedUser;

        #endregion


        #region  Commands

        public ICommand SearchCategoryCommand => new RelayCommand(SearchCategory);
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
            if (CategoryModel == null)
                CategoryModel = new ObservableCollection<CategoryModel>();
            else
                CategoryModel.Clear();

            if (list != null)
            {
                foreach (var rememberZone in list)
                {
                    CategoryModel.Add(rememberZone);
                }
            }
        }
    }
}
