using System.Collections.Generic;
using Remember.Data;
using Remember.Models;

namespace Remember.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryData> GetAll(bool withChildren = false);
        List<CategoryData> GetAll(string filterName, bool withChildren = false, bool local = false);
        Response<CategoryData> Insert(CategoryData rememberZone);
    }
}