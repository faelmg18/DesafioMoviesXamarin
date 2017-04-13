
using MyMovies.Libary.Persistence;

namespace MyMovies.Persistence
{
    public static class RepositoryFactory
    {
      
        private static string GetPahDB()
        {
            string applicationFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Movies");

            // Create the folder path.
            System.IO.Directory.CreateDirectory(applicationFolderPath);

            string databaseFileName = System.IO.Path.Combine(applicationFolderPath, "Movies.db");
            SQLite.SQLite3.Config(SQLite.SQLite3.ConfigOption.Serialized);

            return databaseFileName;
        }

        public static MovieRepository CreateMoviesRepository()
        {
            return new MovieDAO(GetPahDB());
        }
    }
}