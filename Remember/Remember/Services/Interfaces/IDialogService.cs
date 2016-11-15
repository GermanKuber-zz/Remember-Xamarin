using System.Threading.Tasks;

namespace Remember.Services.Interfaces
{
    public interface IDialogService
    {
        Task ShowMessage(string title, string message);
    }
}