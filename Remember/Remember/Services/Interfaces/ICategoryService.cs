using System.Collections.Generic;
using Remember.Data;
using Remember.Models;

namespace Remember.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryModel> GetAll(bool withChildren = false);
        List<CategoryModel> GetAll(string filterName, bool withChildren = false, bool local = false);
        Response<CategoryModel> Insert(CategoryModel rememberZone);
    }
}