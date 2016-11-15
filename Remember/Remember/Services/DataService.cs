using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remember.Data;
using Remember.Model;

namespace Remember.Services
{
    public class DataService
    {
        public Response<User> InsertUser(User user)
        {
            try
            {
                using (var da = new DataAccess())
                {
                    var oldUser = da.First<User>(false);
                    if (oldUser != null)
                    {
                        da.Delete(oldUser);
                    }
                    da.Insert(user);
                }
                return new Response<User>
                {
                    IsSuccess = true,
                    Message = "Usuario Insertado OK!",
                    Result = user
                };
            }
            catch (Exception ex)
            {
                return new Response<User>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Result = null
                };
                throw;
            }
        }
        public User GetUser()
        {
            try
            {
                using (var da = new DataAccess())
                {

                    return da.First<User>(false);

                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return null;
        }
    }
}
