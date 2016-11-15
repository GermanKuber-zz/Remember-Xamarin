using System.Collections.ObjectModel;
using Remember.Models;
using Remember.Services.Interfaces;

namespace Remember.ViewModels
{
    public class CategoryListViewModel
    {
        private readonly ICategoryService _categoryService;
        private readonly ILoginService _loginService;

        #region Properties

        public ObservableCollection<CategoryModel> RemembersZones { get; set; }

        public User LogedUser => _loginService.LogedUser;

        #endregion



        public CategoryListViewModel(ICategoryService categoryService, ILoginService loginService)
        {
            _categoryService = categoryService;
            _loginService = loginService;


            LoadAllRemember();
        }

        private void LoadAllRemember()
        {
            RemembersZones = new ObservableCollection<CategoryModel>();
            var response = this._categoryService.GetAll();
            if (response != null)
            {
                foreach (var rememberZone in response)
                {
                    RemembersZones.Add(rememberZone);
                }
            }
        }
    }
}
