using MoviesApi.Libary.DataBase;
using MoviesApi.Libary.Model.Fundation;
using MoviesApi.Libary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Libary.Persistence
{
    public class MovieDAO : DataBaseMovies<Movie>, MovieRepository
    {


        public MovieDAO(string databasePath, bool storeDateTimeAsTicks = false) : base(databasePath, storeDateTimeAsTicks)
        {

        }

        public MovieDAO(string databasePath) : base(databasePath, false)
        {
        }

        public int Count()
        {
            return base.Count();
        }

        public void DeleteAll()
        {
            List<Movie> movies = RetrieveAll();

            foreach (var item in movies)
            {
                Delete(item);
            }
        }


        public List<Movie> RetrieveAll()
        {
            var movies = FindAll();
            movies = movies.OrderBy(o => o.genre).ToList();
            return movies;
        }

        public List<Movie> RetrieveAllByName(string movieName)
        {
            string query = "Select * from Movie where Title like '%" + movieName + "%'";

            var movie = FindByQuery(query);
            List<Movie> movies = new List<Movie>();
            foreach (var item in movie)
            {
                movies.Add(item);
            }

            return movies;
        }

        public LinkedHashMap<string, List<Movie>> RetrieveAllGroupBy()
        {
            List<Movie> movies = RetrieveAll();
            LinkedHashMap<string, List<Movie>> moviesCategorized = CreateMoviesCategorized(movies);
            return moviesCategorized;
        }

        public Movie RetrieveById(long id)
        {
            return FindById(id);
        }

        public long Save(Movie movie)
        {
            return Insert(movie);
        }

        public void Delete(Movie movie)
        {
            base.Delete(movie);
        }

        private LinkedHashMap<string, List<Movie>> CreateMoviesCategorized(List<Movie> movies)
        {

            LinkedHashMap<string, List<Movie>> hasMapMovies = new LinkedHashMap<string, List<Movie>>();

            foreach (Movie movie in movies)
            {

                if (!hasMapMovies.ContainsKey(movie.Genre))
                {
                    List<Movie> list = new List<Movie>();
                    list.Add(movie);

                    hasMapMovies[movie.Genre] = list;

                }
                else
                {
                    hasMapMovies[movie.Genre].Add(movie);
                }
            }

            return hasMapMovies;
        }

        public Movie FindById(long id)
        {
            return Find(id);
        }

        public long SaveOrUpdate(Movie movie)
        {
            return InsertOrUpdate(movie);
        }
    }
}
