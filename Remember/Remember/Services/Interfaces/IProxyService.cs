using Remember.Models;

namespace Remember.Services.Interfaces
{
    public interface IProxyService
    {
        Response<User> Login(string email, string password);
    }
}