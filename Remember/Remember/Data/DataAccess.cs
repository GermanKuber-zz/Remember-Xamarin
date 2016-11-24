using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using Remember.Interfaces;
using Remember.Models;
using Remember.Repositories;
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

            _connection.CreateTable<Permission>();
            _connection.CreateTable<User>();
            _connection.CreateTable<CategoryModel>();
            _connection.CreateTable<RememberData>();
        }

        public void ClearAllData()
        {
            // _connection.DeleteAll<User>();
            _connection.DeleteAll<CategoryModel>();
            _connection.DeleteAll<RememberData>();
        }

        public void Insert<T>(T model)
        {
            var obj = _connection.Insert(model);
        }

        public void Update<T>(T model)
        {

            var udpated = _connection.Update(model, typeof(T));
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

    public class DataDummy
    {
        public void GenerateDataDummy()
        {

            var dataAccess = new DataAccess();
            var categoryRepository = App.Container.Resolve<ICategoryRepository>();
            var rememberRepository = App.Container.Resolve<IRememberRepository>();
            dataAccess.ClearAllData();

            var comprasCoto = categoryRepository.Insert(new CategoryModel
            {
                Name = "Compras Coto",
                Order = 1,
                Active = true,
                Image = "http://america-retail.com/static/2012/05/Logo-Dir-Arg-Coto.jpg"
            }).Result;

            var cocaCola = rememberRepository.Insert(comprasCoto, new RememberData
            {
                Name = "Coca Cola",
                DebtCount = 1,
                //ExpirationDate = DateTime.Now.AddDays(5),
                Image = "https://cdn.shopify.com/s/files/1/0706/6309/products/coca-cola-botella-desechable-3-litros_large.jpg?v=1441256902"
            }).Result;
            var vinagre = rememberRepository.Insert(comprasCoto, new RememberData
            {
                Name = "Vinagre",
                DebtCount = 1,
                //ExpirationDate = DateTime.Now.AddDays(5),
                Image = "http://www.aurante.com/media/catalog/product/cache/1/thumbnail/9df78eab33525d08d6e5fb8d27136e95/v/i/vinagre-32.jpg"
            }).Result;

            var fideos = rememberRepository.Insert(comprasCoto, new RememberData
            {
                Name = "Fideos",
                DebtCount = 5,
                //ExpirationDate = DateTime.Now.AddDays(9),
                Image = "http://infinito.pe/sites/default/files/fideo-tallarin3.jpg"
            }).Result;


            var duraznos = rememberRepository.Insert(comprasCoto, new RememberData
            {
                Name = "Duraznos en lata",
                DebtCount = 5,
                //ExpirationDate = DateTime.Now.AddDays(9),
                Image = "http://www.ayeimportexport.com.bo/wp-content/uploads/2015/07/duce-sabor.jpg"
            }).Result;


            var casanCrem = rememberRepository.Insert(comprasCoto, new RememberData
            {
                Name = "Casancrem",
                DebtCount = 2,
                //ExpirationDate = DateTime.Now.AddDays(2),
                Image = "http://www.recetaensaladacaesar.com/images/pasos/paso7.jpg"
            }).Result;

            var comprasVerduleria = categoryRepository.Insert(new CategoryModel
            {
                Name = "Compras Verduleria",
                Order = 2,
                Active = true,
                Image = "http://guiaparalacosta.com.ar/comercios/wp-content/uploads/2014/01/Frutas-y-verduras1G.jpg"
            }).Result;


            var kiwi = rememberRepository.Insert(comprasVerduleria, new RememberData
            {
                Name = "Kiwi",
                DebtCount = 2,
                //ExpirationDate = DateTime.Now.AddDays(2),
                Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Kiwi_(Actinidia_chinensis)_2_Luc_Viatour.jpg/220px-Kiwi_(Actinidia_chinensis)_2_Luc_Viatour.jpg"
            }).Result;

            var banana = rememberRepository.Insert(comprasVerduleria, new RememberData
            {
                Name = "Banana",
                DebtCount = 2,
                //ExpirationDate = DateTime.Now.AddDays(2),
                Image = "http://diferenciaentre.info/wp-content/uploads/2014/11/banana.jpg"
            }).Result;
            var melon = rememberRepository.Insert(comprasVerduleria, new RememberData
            {
                Name = "Melón",
                DebtCount = 2,
                //ExpirationDate = DateTime.Now.AddDays(2),
                Image = "http://cde.peru.com/ima/0/1/1/4/2/1142149/611x458/melon.jpg"
            }).Result;
            var palta = rememberRepository.Insert(comprasVerduleria, new RememberData
            {
                Name = "Palta",
                DebtCount = 2,
                //ExpirationDate = DateTime.Now.AddDays(2),
                Image = "http://www.elgastronomo.com.ar/wp-content/uploads/Aguacate-Palta-Engorda.jpg"
            }).Result;



            var comprasFerreteria = categoryRepository.Insert(new CategoryModel
            {
                Name = "Ferreteria",
                Order = 2,
                Active = true,
                Image = "http://2.bp.blogspot.com/-dYWWKuMsLRM/Ur4hHBP9r_I/AAAAAAAAACc/7tHJkJrpyWs/s1600/ferre.png"
            }).Result;
            var clavos = rememberRepository.Insert(comprasFerreteria, new RememberData
            {
                Name = "Clavos",
                DebtCount = 2,
                //ExpirationDate = DateTime.Now.AddDays(2),
                Image = "http://www.cefesa.com/product_images/g/825/clavos__36182_zoom.jpg"
            }).Result;
            var cinta = rememberRepository.Insert(comprasFerreteria, new RememberData
            {
                Name = "Cinta",
                DebtCount = 2,
                //ExpirationDate = DateTime.Now.AddDays(2),
                Image = "http://www.ar.all.biz/img/ar/catalog/61740.jpeg"
            }).Result;

        }
    }
}

