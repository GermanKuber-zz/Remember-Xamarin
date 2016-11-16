
using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Remember.Models
{

    public class CategoryModel
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public string Image { get; set; }

        public int CountRemembers
        {
            get
            {
                if (this.Remembers != null)
                    return this.Remembers.ToList().Count;
                else
                    return 0;
            }
        }
        public string Name { get; set; }
        public int Order { get; set; }

        public bool Active { get; set; }
        [OneToMany]
        public List<RememberModel> Remembers { get; set; }

        public DateTime LastExpiration { get; set; }


    }


}
