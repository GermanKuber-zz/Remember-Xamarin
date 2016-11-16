using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Remember.Models
{
    public class User
    {
        [PrimaryKey]

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public bool IsRemember { get; set; }
        public string Password { get; set; }
        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        //public List<Permission> Permissions { get; set; }

        public override int GetHashCode()
        {
            return UserId;
        }
    }
}
