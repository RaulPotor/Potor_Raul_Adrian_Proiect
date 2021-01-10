using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Potor_Raul_Adrian_Proiect.Models
{
    public class ListMovie
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(WatchList))]
        public int WatchListID { get; set; }
        public int MovieID { get; set; }
    }
}

