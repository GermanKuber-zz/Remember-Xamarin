using System.Collections.Generic;
using Remember.Data;
using Remember.Models;

namespace Remember.Repositories
{
    public interface IRememberRepository
    {
        List<RememberData> GetAll(CategoryModel category, bool withChildren = false);
        Response<RememberData> Insert(CategoryModel category, RememberData rememberZone);
        RememberData GetByExactName(CategoryModel category, string rememberName, bool withChildren = false);
        void Update(RememberData model);
    }
}