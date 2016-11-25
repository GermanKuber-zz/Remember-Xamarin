using System.Threading.Tasks;
using Xamarin.Forms;

namespace Remember.Services
{
    public interface ICamareService
    {
        Task<ImageSource> TakePicture();
    }
}