using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;

namespace Remember.Services
{
    public class CamareService : ICamareService
    {
        public async Task<ImageSource> TakePicture()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "Aceptar");
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Photos",
                Name = "NewRemember.jpg"
            });

            if (file != null)
            {
                var imageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
                return imageSource;
            }
            return null;
        }

    }
}