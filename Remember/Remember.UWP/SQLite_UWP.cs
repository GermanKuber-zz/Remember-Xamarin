

using System.IO;
using Windows.Storage;
using Remember.Interfaces;
using Remember.UWP;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_UWP))]

namespace Remember.UWP
{
    class SQLite_UWP : ISQLite
    {
        public SQLite_UWP()
        {
        }

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "TodoSQLite.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var conn = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            return conn;
        }
    }
}