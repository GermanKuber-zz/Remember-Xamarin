
using System.IO;
using Windows.Storage;
using Remember.Interfaces;
using Remember.UWP;
using Xamarin.Forms;
using SQLite.Net;
using System;

[assembly: Dependency(typeof(SQLite_UWP))]

namespace Remember.UWP
{
    class SQLite_UWP : ISQLite
    {
        public SQLite_UWP()
        {
        }

        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "TodoSQLite.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }

    }
}