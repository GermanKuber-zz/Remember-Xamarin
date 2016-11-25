using System;
using System.Windows.Input;
using Remember.Data;
using Remember.Services;
using Xamarin.Forms;
using XLabs;

namespace Remember.ViewModels.Categories
{
    public class NewCategoryViewModel : ViewModelBase, INavigatedViewModel<object>
    {
        private readonly ICamareService _camareService;


        //public ICommand NewRememberCommand => new RelayCommand(NewRememberAction);

        public ICommand TakePictureCommand => new RelayCommand(TakePicture);



        #region Constructor

        public NewCategoryViewModel(ICamareService camareService)
        {
            _camareService = camareService;
        }

        #endregion
        public override void LoadViewModel()
        {

        }

        public override void UnLoadViewModel()
        {

        }

        public object Parameter { get; set; }


        public void SetParameter(object parameter)
        {
            this.Parameter = parameter;
        }



        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            get
            {
                return _imageSource;

            }
            set
            {
                _imageSource = value;
                OnPropertyChanged();
            }
        }


        private CategoryModel _category;
        public CategoryModel NewCategory
        {
            get
            {
                return _category;

            }
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }

        private async void TakePicture()
        {
            this.ImageSource = await this._camareService.TakePicture();
        }
    }
}