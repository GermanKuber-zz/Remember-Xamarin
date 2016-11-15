using System.Collections.Generic;
using Remember.Models;
using Remember.Repositories;
using Remember.Services.Interfaces;

namespace Remember.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;


        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CategoryModel> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Response<CategoryModel> Insert(CategoryModel rememberZone)
        {
            return _categoryRepository.Insert(rememberZone);
        }
    }
}