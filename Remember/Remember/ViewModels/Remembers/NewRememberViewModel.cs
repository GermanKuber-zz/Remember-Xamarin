using System;
using System.ComponentModel;
using System.Windows.Input;
using Plugin.Media;
using Remember.Models;
using Xamarin.Forms;
using XLabs;

namespace Remember.ViewModels.Remembers
{
    public class NewRememberViewModel : NotificationChangedBase, INavigatedViewModel<CategoryModel>
    {

        public ICommand TakePictureCommand => new RelayCommand(TakePicture);
        private RememberModel _remember;
        public RememberModel Remember
        {
            get { return _remember; }
            set
            {
                _remember = value;
                OnPropertyChanged();
            }
        }

        public CategoryModel Parameter { get; set; }
        public void SetParameter(CategoryModel parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            this.Parameter = parameter;
        }

        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    OnPropertyChanged();
                }
            }
            get
            {
                return _imageSource;
            }
        }


        private async void TakePicture()
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
                ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            }
        }

    }
}
