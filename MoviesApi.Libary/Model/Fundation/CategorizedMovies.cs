using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Libary.Model.Fundation
{
    public class CategorizedMovies
    {

        public List<Movie> Movies { get; set; }
        public string Genere { get; set; }

        public CategorizedMovies(List<Movie> movies, string genere)
        {
            Movies = movies;
            Genere = genere;
        }
    }
}
