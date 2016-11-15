using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Remember.Model
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }

    public class User
    {
        [PrimaryKey]

        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public bool IsRemember { get; set; }
        public string Password { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Permission> Permissions { get; set; }

        public override int GetHashCode()
        {
            return UserId;
        }
    }

    public class Permission
    {
        [PrimaryKey]
        public int PermissionId { get; set; }
        public override int GetHashCode()
        {
            return PermissionId;
        }
    }
}
