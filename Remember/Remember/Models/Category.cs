using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Remember.Models
{

    public class CategoryModel
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public string Image { get; set; }

        public int CountRemembers { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public bool Active { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<RememberModel> Remembers { get; set; }

        public DateTime LastExpiration { get; set; }


    }


}
