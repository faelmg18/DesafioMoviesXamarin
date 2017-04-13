using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Libary.Model.Fundation
{
    public class EntitiePersistable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
