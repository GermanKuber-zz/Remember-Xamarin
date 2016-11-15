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

        public List<CategoryModel> GetAll()
        {
            using (var da = new DataAccess())
            {
                return da.GetList<CategoryModel>(false);
            }
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
