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

        public List<CategoryData> GetAll(bool withChildren = false)
        {
            using (var da = new DataAccess())
            {
                var list = da.GetList<CategoryData>(withChildren);
                return list;
            }
        }

        public Response<CategoryData> Insert(CategoryData model)
        {
            using (var da = new DataAccess())
            {
                try
                {
                    da.Insert<CategoryData>(model);
                    return new Response<CategoryData>
                    {
                        IsSuccess = true,
                        Result = model
                    };
                }
                catch (Exception ex)
                {
                    return new Response<CategoryData>
                    {
                        IsSuccess = false,
                        Message = ex.Message
                    };
                }

            }
        }
    }
}
