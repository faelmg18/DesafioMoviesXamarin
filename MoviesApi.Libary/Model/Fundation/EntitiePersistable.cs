using SQLite;

namespace MoviesApi.Libary.Model.Fundation
{
    public class EntitiePersistable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
