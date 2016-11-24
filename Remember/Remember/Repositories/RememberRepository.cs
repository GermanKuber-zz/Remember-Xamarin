using System;
using System.Collections.Generic;
using System.Linq;
using Remember.Data;
using Remember.Models;

namespace Remember.Repositories
{
    public class RememberRepository : IRememberRepository
    {
        public List<RememberData> GetAll(CategoryModel category, bool withChildren = false)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            using (var da = new DataAccess())
            {
                return da.GetList<RememberData>(withChildren)?.Where(x => x.CategoryId == category.Id)?.ToList();
            }
        }

        public Response<RememberData> Insert(CategoryModel category, RememberData data)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            if (data == null)
                throw new ArgumentNullException(nameof(data));

            data.Category = category;
            data.CategoryId = category.Id;
            using (var da = new DataAccess())
            {
                try
                {
                    da.Insert<RememberData>(data);
                    return new Response<RememberData>
                    {
                        IsSuccess = true,
                        Result = data
                    };
                }
                catch (Exception ex)
                {
                    return new Response<RememberData>
                    {
                        IsSuccess = false,
                        Message = ex.Message
                    };
                }

            }
        }

        public RememberData GetByExactName(CategoryModel category, string rememberName, bool withChildren = false)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            using (var da = new DataAccess())
            {
                return da.GetList<RememberData>(withChildren)?.FirstOrDefault(x => x.Name.ToUpper() == rememberName.ToUpper());
            }
        }

        public void Update(RememberData model)
        {
            using (var da = new DataAccess())
            {
                da.Update(model);
            }
        }
    }
}