using System.Collections.Generic;
using Remember.Data;
using Remember.Models;

namespace Remember.Repositories
{
    public interface ICategoryRepository
    {
        List<CategoryData> GetAll(bool withChildren = false);
        Response<CategoryData> Insert(CategoryData rememberZone);
    }
}