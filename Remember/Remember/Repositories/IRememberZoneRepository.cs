using System.Collections.Generic;
using Remember.Models;

namespace Remember.Repositories
{
    public interface ICategoryRepository
    {
        List<CategoryModel> GetAll();
        Response<CategoryModel> Insert(CategoryModel rememberZone);
    }
}