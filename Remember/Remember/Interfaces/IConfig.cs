

using SQLite.Net;

namespace Remember.Interfaces
{
    public interface IConfig
    {
        string DirectoryDb { get; }
        //ISQLitePlatform Platform { get; }
    }
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
