using System.Collections.Generic;
using Remember.Models;

namespace Remember.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryModel> GetAll(bool local = false);
        List<CategoryModel> GetAll(string filterName, bool local = false);
        Response<CategoryModel> Insert(CategoryModel rememberZone);
    }
}