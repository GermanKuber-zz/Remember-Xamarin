using System.Collections.Generic;
using Remember.Models;

namespace Remember.Services
{
    public interface IRememberService
    {
        List<RememberModel> GetAll(CategoryModel category, bool local = false);
        List<RememberModel> GetAll(CategoryModel category, string filterName, bool local = false);
        Response<RememberModel> Insert(CategoryModel category, RememberModel rememberZone);
    }
}