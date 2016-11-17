using System;
using Remember.Models;
using Remember.Services.Interfaces;

namespace Remember.Services
{
    public class LoginService : ILoginService
    {
        private readonly IDataService _dataService;
        private readonly IProxyService _proxyService;
        private readonly INetService _netService;

        public LoginService(IDataService dataService, IProxyService proxyService, INetService netService)
        {
            _dataService = dataService;
            _proxyService = proxyService;
            _netService = netService;
        }

        public Response<User> Login(string email, string password, bool remember = false)
        {
            if (_netService.IsConnected())
            {
                //Si hay conexion
                var response = _proxyService.Login(email, password);

                if (response.IsSuccess)
                {

                    response.Result.IsRemember = remember;
                    return _dataService.Insert(response.Result);

                }
                else
                {
                    return response;
                }
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
            //var database = DependencyService.Get<ISQLite>();


            //database.GetConnection().CreateTable<User>();
        }
    }
}
