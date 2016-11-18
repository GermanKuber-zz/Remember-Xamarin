using System.Threading.Tasks;
using Remember.Services.Navigation.Interfaces;

namespace Remember.Services.Navigation
{
    public class BackService : IBackService
    {
        private readonly INavigationService _navigationService;

        public BackService(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public async Task Back()
        {

            await _navigationService.Back();

        }
    }
}