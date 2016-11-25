using System.Collections.Generic;
using Remember.Data;
using Remember.Models;

namespace Remember.Services.Interfaces
{
    public interface IRememberService
    {
        List<RememberModel> GetAll(CategoryData category, bool local = false);
        List<RememberModel> GetAllNoCompleted(CategoryData category, bool local = false);
        List<RememberModel> GetAll(CategoryData category, string filterName, bool local = false);
        List<RememberModel> GetAllNoCompleted(CategoryData category, string filterName, bool local = false);
        Response<RememberModel> Insert(CategoryData category, RememberModel rememberZone);
        RememberModel GetByExactName(CategoryData category, string rememberName, bool local = false);
        void Update(RememberModel remember);
    }
}