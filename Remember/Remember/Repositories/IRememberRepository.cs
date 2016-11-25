using System.Collections.Generic;
using Remember.Data;
using Remember.Models;

namespace Remember.Repositories
{
    public interface IRememberRepository
    {
        List<RememberData> GetAll(CategoryData category, bool withChildren = false);
        Response<RememberData> Insert(CategoryData category, RememberData rememberZone);
        RememberData GetByExactName(CategoryData category, string rememberName, bool withChildren = false);
        void Update(RememberData model);
    }
}