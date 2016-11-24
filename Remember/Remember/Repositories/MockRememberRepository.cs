using System;
using System.Collections.Generic;
using System.Linq;
using Remember.Data;
using Remember.Models;

namespace Remember.Repositories
{
    public class MockRememberRepository : IRememberRepository
    {
        private List<RememberData> _list;

        public MockRememberRepository()
        {

        }

        private void GetAllRemembers(CategoryModel category)
        {
            _list = new List<RememberData>();
            if (DbContext.Categories != null)
            {
                foreach (var categorie in DbContext.Categories)
                {
                    if (categorie.Id == category.Id)
                    {

                        if (category.Remembers != null)
                        {
                            foreach (var remember in categorie.Remembers)
                            {
                                _list.Add(remember);
                            }
                        }
                    }

                }
            }
        }
        private RememberData GetRemember(RememberData model)
        {
            _list = new List<RememberData>();
            if (DbContext.Categories != null)
            {
                foreach (var categorie in DbContext.Categories)
                {


                    foreach (var remember in categorie.Remembers)
                    {
                        if (remember.Id == model.Id)
                            return remember;
                    }
                }
            }
            return null;
        }


        public List<RememberData> GetAll(CategoryModel category)
        {
            GetAllRemembers(category);
            return _list;
        }

        public RememberData GetByExactName(CategoryModel category, string rememberName)
        {
            GetAllRemembers(category);



            return _list.FirstOrDefault(x => x.Name.ToUpper() == rememberName.ToUpper());
        }

        public void Update(RememberData model)
        {

            _list = new List<RememberData>();
            if (DbContext.Categories != null)
            {
                foreach (var categorie in DbContext.Categories)
                {


                    foreach (var remember in categorie.Remembers)
                    {
                        if (remember.Id == model.Id)
                        {
                            categorie.Remembers.Remove(remember);
                            categorie.Remembers.Add(model);
                            return;

                        }
                    }
                }
            }
        }



        public Response<RememberData> Insert(RememberData rememberZone)
        {
            using (var da = new DataAccess())
            {
                try
                {
                    da.Insert<RememberData>(rememberZone);
                    return new Response<RememberData>
                    {
                        IsSuccess = true,
                        Result = rememberZone
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
    }
}