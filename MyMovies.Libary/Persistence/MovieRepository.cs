using MyMovies.Libary.Model.Fundation;
using MyMovies.Libary.Utils;
using System.Collections.Generic;

namespace MyMovies.Libary.Persistence
{
    public interface MovieRepository : BaseRepository
    {
        List<Movie> RetrieveAll();
        List<Movie> RetrieveAllByName(string movieName);
        LinkedHashMap<string, List<Movie>> RetrieveAllGroupBy();
        Movie RetrieveById(long id);
        long Save(Movie movie);
        long SaveOrUpdate(Movie movie);
        Movie FindById(long id);
    }
}
