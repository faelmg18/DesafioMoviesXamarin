using MoviesApi.Libary.Model.Fundation;
using MoviesApi.Libary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Libary.Persistence
{
    public interface MovieRepository : BaseRepository
    {
        List<Movie> RetrieveAll();
        void Delete(Movie movie);
        List<Movie> RetrieveAllByName(string movieName);
        LinkedHashMap<string, List<Movie>> RetrieveAllGroupBy();
        Movie RetrieveById(long id);
        long Save(Movie movie);
        long SaveOrUpdate(Movie movie);
        Movie FindById(long id);
    }
}
