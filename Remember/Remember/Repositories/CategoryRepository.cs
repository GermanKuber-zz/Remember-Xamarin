using System;
using System.Collections.Generic;
using Remember.Data;
using Remember.Models;
using Remember.Services.Interfaces;

namespace Remember.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IApiService _apiService;

        public CategoryRepository(IApiService apiService)
        {
            _apiService = apiService;
        }

        public List<CategoryModel> GetAll(bool withChildren = false)
        {
            using (var da = new DataAccess())
            {
                var list = da.GetList<CategoryModel>(withChildren);
                return list;
            }
        }

        public Response<CategoryModel> Insert(CategoryModel model)
        {
            using (var da = new DataAccess())
            {
                try
                {
                    da.Insert<CategoryModel>(model);
                    return new Response<CategoryModel>
                    {
                        IsSuccess = true,
                        Result = model
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
