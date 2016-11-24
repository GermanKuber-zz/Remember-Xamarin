using System.Collections.Generic;
using System.Linq;
using Remember.Models;
using Remember.Repositories;
using Remember.Services.Interfaces;

namespace Remember.Services
{
    public class RememberService : IRememberService
    {
        private readonly IRememberRepository _rememberRepository;
        private readonly IApiService _apiService;

        private readonly INetService _netService;


        public RememberService(IRememberRepository rememberRepository, IApiService apiService, INetService netService)
        {
            _rememberRepository = rememberRepository;
            _apiService = apiService;


            _netService = netService;
        }

        public List<RememberModel> GetAll(CategoryModel category, bool local = false)
        {
            return _rememberRepository.GetAll(category);
        }

        public void Update(RememberModel model)
        {
            if (_netService.IsConnected())
            {
                //TODO : ejecutar remoto
            }
            _rememberRepository.Update(model);
        }

        public RememberModel GetByExactName(CategoryModel category, string rememberName, bool local = false)
        {
            return _rememberRepository.GetByExactName(category, rememberName);
        }
        public List<RememberModel> GetAll(CategoryModel category, string filterName, bool local = false)
        {
            if (local)
            {
                var list = _rememberRepository.GetAll(category).Where(x => x.Name.ToUpper().Contains(filterName.ToUpper())).OrderBy(x => x.Name).ToList();
                return list;
            }
            else
            {
                //TODO: COnsulta remoto
                var list = _rememberRepository.GetAll(category).Where(x => x.Name.ToUpper().Contains(filterName.ToUpper())).OrderBy(x => x.Name).ToList();
                return list;
            }
        }

        public Response<RememberModel> Insert(CategoryModel category, RememberModel rememberZone)
        {
            return _rememberRepository.Insert(rememberZone);
        }
    }
}