using System;
using Remember.Data;
using Remember.Models;
using Remember.Services.Interfaces;

namespace Remember.Services
{
    public class DataService : IDataService
    {
        public Response<T> Update<T>(T data)
        {
            try
            {
                using (var da = new DataAccess())
                {

                    da.Update(data);
                }
                return new Response<T>
                {
                    IsSuccess = true,
                    Message = "Actualizado OK!",
                    Result = data
                };
            }
            catch (Exception ex)
            {
                return new Response<T>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
                throw;
            }
        }
        public Response<T> Insert<T>(T data) where T : class
        {
            try
            {
                using (var da = new DataAccess())
                {
                    var oldData = da.First<T>(false);
                    if (oldData != null)
                    {
                        da.Delete(oldData);
                    }
                    da.Insert(data);
                }
                return new Response<T>
                {
                    IsSuccess = true,
                    Message = "Insertado OK!",
                    Result = data
                };
            }
            catch (Exception ex)
            {
                return new Response<T>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
                throw;
            }
        }
        public Response<T> Delete<T>(T data) where T : class
        {
            try
            {
                using (var da = new DataAccess())
                {
                    var oldData = da.First<T>(false);
                    if (oldData != null)
                    {
                        da.Delete(oldData);
                    }
                }
                return new Response<T>
                {
                    IsSuccess = true,
                    Message = "Eliminado OK!",
                    Result = data
                };
            }
            catch (Exception ex)
            {
                return new Response<T>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
                throw;
            }
        }
        public T GetFirst<T>() where T : class
        {
            try
            {
                using (var da = new DataAccess())
                {

                    return da.First<T>(false);

                }

            }
            catch (Exception ex)
            {


            }
            return null;
        }
    }
}
