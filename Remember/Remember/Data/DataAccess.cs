using System;
using System.Collections.Generic;
using System.Linq;
using Remember.Interfaces;
using Remember.Models;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace Remember.Data
{
    public class DataAccess : IDisposable
    {
        private readonly SQLiteConnection _connection;

        public DataAccess()
        {
            var config = DependencyService.Get<ISQLite>();
            _connection = config.GetConnection();


            //_connection.DeleteAll<User>();
            //_connection.DeleteAll<CategoryModel>();
            //_connection.DeleteAll<RememberData>();

            _connection.CreateTable<Permission>();
            _connection.CreateTable<User>();
            _connection.CreateTable<CategoryModel>();
            _connection.CreateTable<RememberData>();
        }

        public void Insert<T>(T model)
        {
            _connection.Insert(model);
        }

        public void Update<T>(T model)
        {
            _connection.Update(model);
        }

        public void Delete<T>(T model)
        {
            _connection.Delete(model);
        }

        public T First<T>(bool WithChildren) where T : class
        {
            if (WithChildren)
            {
                return _connection.GetAllWithChildren<T>().FirstOrDefault();
            }
            else
            {
                return _connection.Table<T>().FirstOrDefault();
            }
        }

        public List<T> GetList<T>(bool WithChildren) where T : class
        {
            if (WithChildren)
            {
                return _connection.GetAllWithChildren<T>().ToList();
            }
            else
            {
                return _connection.Table<T>().ToList();
            }
        }

        public T Find<T>(int pk, bool WithChildren) where T : class
        {
            if (WithChildren)
            {
                return _connection.GetAllWithChildren<T>().FirstOrDefault(m => m.GetHashCode() == pk);
            }
            else
            {
                return _connection.Table<T>().FirstOrDefault(m => m.GetHashCode() == pk);
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}

