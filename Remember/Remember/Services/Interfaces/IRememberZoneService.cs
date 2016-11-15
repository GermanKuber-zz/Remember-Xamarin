using System.Collections.Generic;
using Remember.Models;

namespace Remember.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryModel> GetAll();
        Response<CategoryModel> Insert(CategoryModel rememberZone);
    }
}