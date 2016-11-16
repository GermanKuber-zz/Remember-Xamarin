using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Remember.Models
{

    public class RememberModel
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
}
