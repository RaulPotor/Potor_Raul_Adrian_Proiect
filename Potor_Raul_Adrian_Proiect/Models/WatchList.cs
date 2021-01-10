using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Potor_Raul_Adrian_Proiect.Models
{
    public class WatchList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
