using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Libary.Persistence
{
    public interface BaseRepository
    {
        void DeleteAll();
        int Count();
    }
}
