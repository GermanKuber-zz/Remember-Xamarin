using Remember.Models;

namespace Remember.Services.Interfaces
{
    public interface IDataService
    {
        Response<T> Delete<T>(T data) where T : class;
        T GetFirst<T>() where T : class;
        Response<T> Insert<T>(T data) where T : class;
        Response<T> Update<T>(T data);
    }
}