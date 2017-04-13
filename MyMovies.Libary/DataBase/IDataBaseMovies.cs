using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Libary.DataBase
{
    public interface IDataBaseMovies<T>
    {
        int InsertOrUpdate(T data);
        T Find(T obj);
        List<T> FindByQuery(string query);
        int Delete(T data);
    }
}
