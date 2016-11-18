using Remember.Models;

namespace Remember.Services.Interfaces
{
    public interface ILoginService
    {
        bool IsLogued { get; }
        User LogedUser { get; }

        Response<User> Login(string email, string password, bool remember = false);
        Response<bool> LogOut();
        Response<User> Register(User registerUser);
    }
}