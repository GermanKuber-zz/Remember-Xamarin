using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remember.Interfaces;
using Remember.Model;
using Xamarin.Forms;

namespace Remember.Services
{
    public class LoginService
    {

        public LoginService()
        {

        }

        public async Task<Response<User>> Login(string email, string password, bool remember = false)
        {
            var user = new User
            {
                Email = email,
                FirstName = "Germán",
                LastName = "Küber"
            };
            if (remember)
            {
                this.Recordar(user);
            }
            user.IsRemember = remember;
            return App.DataService.InsertUser(user);
        }

        private void Recordar(User user)
        {
            var database = DependencyService.Get<ISQLite>();


            database.GetConnection().CreateTable<User>();
        }
    }
}
