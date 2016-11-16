using System.Collections.Generic;
using Remember.Models;

namespace Remember.Repositories
{
    public interface IRememberRepository
    {
        List<RememberModel> GetAll(CategoryModel category);
        Response<RememberModel> Insert(RememberModel rememberZone);
        RememberModel GetByExactName(CategoryModel category, string rememberName);
    }
}