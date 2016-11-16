

using SQLite;
using SQLite.Net.Interop;

namespace Remember.Interfaces
{
    public interface IConfig
    {
        string DirectoryDb { get; }
        ISQLitePlatform Platform { get; }
    }
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
