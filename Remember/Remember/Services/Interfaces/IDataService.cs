using Remember.Data;
using Remember.Models;

namespace Remember.Services.Interfaces
{
    public interface IDataService
    {
        Response<T> Delete<T>(T data) where T : class, new();
        T GetFirst<T>() where T : class, new();
        Response<T> Insert<T>(T data) where T : class, new();
        Response<T> Update<T>(T data);
    }
}