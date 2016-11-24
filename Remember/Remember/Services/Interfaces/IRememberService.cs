using System.Collections.Generic;
using Remember.Data;
using Remember.Models;

namespace Remember.Services.Interfaces
{
    public interface IRememberService
    {
        List<RememberModel> GetAll(CategoryModel category, bool local = false);
        List<RememberModel> GetAllNoCompleted(CategoryModel category, bool local = false);
        List<RememberModel> GetAll(CategoryModel category, string filterName, bool local = false);
        List<RememberModel> GetAllNoCompleted(CategoryModel category, string filterName, bool local = false);
        Response<RememberModel> Insert(CategoryModel category, RememberModel rememberZone);
        RememberModel GetByExactName(CategoryModel category, string rememberName, bool local = false);
        void Update(RememberModel remember);
    }
}