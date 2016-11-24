using SQLite;

namespace Remember.Data
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