using System.Collections.Generic;
using Remember.Data;
using Remember.Models;

namespace Remember.Repositories
{
    public interface ICategoryRepository
    {
        List<CategoryModel> GetAll(bool withChildren = false);
        Response<CategoryModel> Insert(CategoryModel rememberZone);
    }
}