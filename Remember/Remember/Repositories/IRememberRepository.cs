using System.Collections.Generic;
using Remember.Models;

namespace Remember.Repositories
{
    public interface IRememberRepository
    {
        List<RememberData> GetAll(CategoryModel category);
        Response<RememberData> Insert(RememberData rememberZone);
        RememberData GetByExactName(CategoryModel category, string rememberName);
        void Update(RememberData model);
    }
}