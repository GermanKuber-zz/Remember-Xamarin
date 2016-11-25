using System;
using System.Collections.Generic;
using System.Linq;
using Remember.ViewModels;
using SQLiteNetExtensions.Attributes;

namespace Remember.Data
{
    public class CategoryModel : NotificationChangedBase
    {


        public CategoryData CategoryData { get; set; }

        private string _image;



        public string Image
        {
            get
            {
                return _image;

            }
            set
            {
                _image = value;
                this.CategoryData.Image = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;

            }
            set
            {
                _name = value;
                this.CategoryData.Name = value;
                OnPropertyChanged();
            }
        }

        public CategoryModel()
        {

        }

        public CategoryModel(CategoryData categoryData)
        {
            this.CategoryData = categoryData;
            this.Image = categoryData.Image;
            this.Name = categoryData.Name;
        }

    }
}