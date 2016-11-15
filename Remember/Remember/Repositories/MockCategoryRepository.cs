using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Remember.Data;
using Remember.Models;

namespace Remember.Repositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        private List<CategoryModel> _list;

        public MockCategoryRepository()
        {
            _list = new List<CategoryModel> {
            new CategoryModel {
                Name = "Compras Coto",
                Order = 1,
                Active = true,
                Image = "http://america-retail.com/static/2012/05/Logo-Dir-Arg-Coto.jpg",
                Remembers = new List<RememberModel> {
                    new RememberModel {
                        Name = "Coca Cola",
                         DebtCount  = 1,
                         ExpirationDate = DateTime.Now.AddDays(5),
                         Image = "https://cdn.shopify.com/s/files/1/0706/6309/products/coca-cola-botella-desechable-3-litros_large.jpg?v=1441256902"
                    },
                            new RememberModel {
                        Name = "Fideos",
                         DebtCount  = 5,
                         ExpirationDate = DateTime.Now.AddDays(9),
                         Image = "http://infinito.pe/sites/default/files/fideo-tallarin3.jpg"
                    },
                                    new RememberModel {
                        Name = "Casancrem",
                         DebtCount  = 2,
                         ExpirationDate = DateTime.Now.AddDays(2),
                         Image = "http://www.recetaensaladacaesar.com/images/pasos/paso7.jpg"
                    }
                }
            },   new CategoryModel {
                Name = "Chino",
                Order = 1,
                Active = true
            },   new CategoryModel {
                Name = "Compras Coto",
                Order = 1,
                Active = true
            },   new CategoryModel {
                Name = "Compras Coto",
                Order = 1,
                Active = true
            }};
        }
        public List<CategoryModel> GetAll()
        {
            return _list;
        }

        public Response<CategoryModel> Insert(CategoryModel rememberZone)
        {
            using (var da = new DataAccess())
            {
                try
                {
                    da.Insert<CategoryModel>(rememberZone);
                    return new Response<CategoryModel>
                    {
                        IsSuccess = true,
                        Result = rememberZone
                    };
                }
                catch (Exception ex)
                {
                    return new Response<CategoryModel>
                    {
                        IsSuccess = false,
                        Message = ex.Message
                    };
                }

            }
        }
    }
}