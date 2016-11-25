using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Remember.Data;
using Remember.Services.Interfaces;
using Remember.Services.Navigation.Interfaces;

namespace Remember.ViewModels.Categories
{
    public class CategoryListViewModel : ViewModelBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILoginService _loginService;
        private readonly IRememberPageView _rememberPageView;
        private readonly INewCategoryPageView _newCategorypage;

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

        private CategoryData _categorySelected;
        public CategoryData CategorySelected
        {
            get
            {
                return _categorySelected;

            }
            set
            {
                if (_categorySelected != value)
                {

                    _categorySelected = value;
                    OnPropertyChanged();
                    SelectCategory();
                }
            }
        }
        public ObservableCollection<CategoryData> CategoryList { get; set; }

        public User LogedUser => _loginService.LogedUser;

        #endregion


        #region  Commands

        public ICommand SearchCategoryCommand => new RelayCommand(SearchCategory);

        public ICommand NewCategoryCommand => new RelayCommand(NewCategory);

        private void NewCategory()
        {
            _newCategorypage.Navigate(null);
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
            LoadAll(response);
        }

        #endregion

        public CategoryListViewModel(ICategoryService categoryService,
            ILoginService loginService,
            IRememberPageView rememberPageView,
            INewCategoryPageView newCategorypage)
        {
            _categoryService = categoryService;
            _loginService = loginService;
            _rememberPageView = rememberPageView;
            _newCategorypage = newCategorypage;

            var response = this._categoryService.GetAll(true);
            LoadAll(response);
        }

        private void LoadAll(List<CategoryData> list)
        {
            if (CategoryList == null)
                CategoryList = new ObservableCollection<CategoryData>();
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
            var response = this._categoryService.GetAll(true);
            LoadAll(response);
            CategorySelected = null;
        }

        public override void UnLoadViewModel()
        {
            throw new System.NotImplementedException();
        }
    }
}
