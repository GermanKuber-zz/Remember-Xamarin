using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
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
