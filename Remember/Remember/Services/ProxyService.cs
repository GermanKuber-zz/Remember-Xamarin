using Remember.Models;
using Remember.Services.Interfaces;

namespace Remember.Services
{
    public class ProxyService : IProxyService
    {
        public Response<User> Login(string email, string password)
        {
            if (email.ToUpper() == "GERMAN.KUBER@OUTLOOK.COM" && password.ToUpper() == "GERMAN.KUBER@OUTLOOK.COM")
            {

                return new Response<User>
                {
                    IsSuccess = true,
                    Result = new User
                    {
                        Email = email,
                        Password = password,
                        FirstName = "Germán",
                        LastName = "Küber",
                        Id = 1,
                        Image = "http://germankuber.com.ar/wp-content/uploads/2016/10/4.jpg"

                    }
                };
            }
            if (email.ToUpper() == "A@A.com" && password.ToUpper() == "A@A.com")
            {

                return new Response<User>
                {
                    IsSuccess = true,
                    Result = new User
                    {
                        Email = email,
                        Password = password,
                        FirstName = "A First Name",
                        LastName = "A Last Name",
                        Id = 2,
                        Image =
                            "http://previews.123rf.com/images/glopphy/glopphy1211/glopphy121100003/16099620-Una-carta-de-oro-con-adornos-swirly-Foto-de-archivo.jpg"

                    }
                };
            }
            else
            {
                return new Response<User>
                {
                    IsSuccess = false
                };
            }
        }
    }
}
