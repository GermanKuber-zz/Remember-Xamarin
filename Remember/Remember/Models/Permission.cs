using SQLite.Net.Attributes;

namespace Remember.Models
{
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