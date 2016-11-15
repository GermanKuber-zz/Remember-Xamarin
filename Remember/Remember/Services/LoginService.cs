using System;
using System.Threading.Tasks;
using Remember.Interfaces;
using Remember.Models;
using Remember.Services.Interfaces;
using Xamarin.Forms;

namespace Remember.Services
{
    public class LoginService : ILoginService
    {
        private readonly IDataService _dataService;
        private readonly INetService _netService;

        public LoginService(IDataService dataService, INetService netService)
        {
            _dataService = dataService;
            _netService = netService;
        }

        public Response<User> Login(string email, string password, bool remember = false)
        {
            if (_netService.IsConnected())
            {
                var user = new User
                {
                    Email = email,
                    FirstName = "Germán",
                    LastName = "Küber",
                    Image = "http://germankuber.com.ar/wp-content/uploads/2016/10/4.jpg"

                };
                if (remember)
                {
                    this.Recordar(user);
                }
                user.IsRemember = remember;
                return _dataService.Insert(user);
            }
            else
            {
                //Si no hay conexion
                var user = _dataService.GetFirst<User>();
                if (user != null)
                {
                    if (user.Email.ToUpper() == email && user.Password.ToUpper() == password)
                        return new Response<User>
                        {
                            IsSuccess = true,
                            Result = user
                        };
                    else
                    {
                        return new Response<User>
                        {
                            IsSuccess = false,
                            Message = "No hay conexion a internet y un usuario nunca se logueo"
                        };
                    }
                }
                else
                {
                    return new Response<User>
                    {
                        IsSuccess = false,
                        Message = "No hay conexion a internet y un usuario nunca se logueo"
                    };
                }

            }
        }

        public User LogedUser => _dataService.GetFirst<User>();

        public bool IsLogued
        {
            get
            {
                var userLoged = _dataService.GetFirst<User>();
                if (userLoged != null)
                    return true;
                else
                    return false;
            }
        }

        public Response<bool> LogOut()
        {
            try
            {
                var user = _dataService.GetFirst<User>();
                _dataService.Delete(user);
                return new Response<bool>
                {
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {

                return new Response<bool>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }


        }

        private void Recordar(User user)
        {
            var database = DependencyService.Get<ISQLite>();


            database.GetConnection().CreateTable<User>();
        }
    }
}
