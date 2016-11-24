using System.Windows.Input;
using AutoMapper;
using GalaSoft.MvvmLight.Command;
using Remember.ViewModels;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Remember.Models
{

    public class RememberData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int DebtCount { get; set; }
        //public DateTime ExpirationDate { get; set; }
        public bool Completed { get; set; }
        public bool Active { get; set; }
        public string Note { get; set; }
        public decimal Price { get; set; }
        [ForeignKey(typeof(CategoryModel))]
        public string CategoryId { get; set; }
        [ManyToOne]
        public CategoryModel Category { get; set; }


        public override int GetHashCode()
        {
            return Id;

        }
    }

    public class RememberModel : NotificationChangedBase
    {
        public RememberData RememberData { get; set; }

        public int Id { get; }

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
                this.RememberData.Image = value;
                OnPropertyChanged();
            }
        }

        private int _debtCount;
        public int DebtCount
        {
            get
            {
                return _debtCount;

            }
            set
            {
                _debtCount = value;
                this.RememberData.DebtCount = value;
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
                this.RememberData.Name = value;
                OnPropertyChanged();
            }
        }

        private string _note;
        public string Note
        {
            get
            {
                return _note;

            }
            set
            {
                _note = value;
                this.RememberData.Note = value;
                OnPropertyChanged();
            }
        }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                this.RememberData.Price = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddDebtCommand => new RelayCommand(AddDebt);
        public ICommand PopDebtCommand => new RelayCommand(PopDebt);

        private void AddDebt()
        {
            ++this.DebtCount;
        }
        private void PopDebt()
        {
            if (this.DebtCount > 0)
                --this.DebtCount;
        }


        public RememberModel()
        {

        }
        public RememberModel(RememberData remember)
        {
            this.RememberData = remember;

            this.Id = remember.Id;
            this.Name = remember.Name;
            this.Image = remember.Image;
            this.Price = remember.Price;
            this.Note = remember.Note;
            this.DebtCount = remember.DebtCount;
        }
    }
}
