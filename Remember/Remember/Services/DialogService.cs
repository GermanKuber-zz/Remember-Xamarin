using System.Threading.Tasks;
using Remember.Services.Interfaces;

namespace Remember.Services
{
    public class DialogService : IDialogService
    {
        public async Task ShowMessage(string title, string message)
        {
            await App.Current.MainPage.DisplayAlert(title, message, "Aceptar");
        }
    }
}
