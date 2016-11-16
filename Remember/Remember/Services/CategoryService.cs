using System.Collections.Generic;
using System.Linq;
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

        public List<CategoryModel> GetAll(bool local = false)
        {
            return _categoryRepository.GetAll();
        }
        public List<CategoryModel> GetAll(string filterName, bool local = false)
        {
            if (local)
            {
                var list = _categoryRepository.GetAll().Where(x => x.Name.ToUpper().Contains(filterName.ToUpper())).OrderBy(x => x.Name).ToList();
                return list;
            }
            else
            {
                //TODO: COnsulta remoto
                var list = _categoryRepository.GetAll().Where(x => x.Name.ToUpper().Contains(filterName.ToUpper())).OrderBy(x => x.Name).ToList();
                return list;
            }
        }

        public Response<CategoryModel> Insert(CategoryModel rememberZone)
        {
            return _categoryRepository.Insert(rememberZone);
        }
    }

    public class RememberService : IRememberService
    {
        private readonly IRememberRepository _rememberRepository;
        private readonly IApiService _apiService;

        private readonly INetService _netService;


        public RememberService(IRememberRepository rememberRepository, IApiService apiService, INetService netService)
        {
            _rememberRepository = rememberRepository;
            _apiService = apiService;


            _netService = netService;
        }

        public List<RememberModel> GetAll(CategoryModel category, bool local = false)
        {
            return _rememberRepository.GetAll(category);
        }
        public RememberModel GetByExactName(CategoryModel category, string rememberName, bool local = false)
        {
            return _rememberRepository.GetByExactName(category, rememberName);
        }
        public List<RememberModel> GetAll(CategoryModel category, string filterName, bool local = false)
        {
            if (local)
            {
                var list = _rememberRepository.GetAll(category).Where(x => x.Name.ToUpper().Contains(filterName.ToUpper())).OrderBy(x => x.Name).ToList();
                return list;
            }
            else
            {
                //TODO: COnsulta remoto
                var list = _rememberRepository.GetAll(category).Where(x => x.Name.ToUpper().Contains(filterName.ToUpper())).OrderBy(x => x.Name).ToList();
                return list;
            }
        }

        public Response<RememberModel> Insert(CategoryModel category, RememberModel rememberZone)
        {
            return _rememberRepository.Insert(rememberZone);
        }
    }
}