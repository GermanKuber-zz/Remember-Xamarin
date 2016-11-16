

using System.Threading.Tasks;
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
    public interface IQrCodeScanningService
    {
        Task<string> ScanAsync();
    }

}
