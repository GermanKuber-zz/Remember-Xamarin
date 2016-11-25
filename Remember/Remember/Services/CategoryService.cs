using System.Collections.Generic;
using System.Linq;
using Remember.Data;
using Remember.Models;
using Remember.Repositories;
using Remember.Services.Interfaces;

namespace Remember.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IApiService _apiService;

        private readonly INetService _netService;


        public CategoryService(ICategoryRepository categoryRepository, IApiService apiService, INetService netService)
        {
            _categoryRepository = categoryRepository;
            _apiService = apiService;


            _netService = netService;
        }

        public List<CategoryData> GetAll(bool withChildren = false)
        {
            return _categoryRepository.GetAll(withChildren);
        }
        public List<CategoryData> GetAll(string filterName, bool withChildren = false, bool local = false)
        {
            if (local)
            {
                var list = _categoryRepository.GetAll(withChildren).Where(x => x.Name.ToUpper().Contains(filterName.ToUpper())).OrderBy(x => x.Name).ToList();
                return list;
            }
            else
            {
                //TODO: COnsulta remoto
                var list = _categoryRepository.GetAll(withChildren).Where(x => x.Name.ToUpper().Contains(filterName.ToUpper())).OrderBy(x => x.Name).ToList();
                return list;
            }
        }

        public Response<CategoryData> Insert(CategoryData rememberZone)
        {
            return _categoryRepository.Insert(rememberZone);
        }
    }
}