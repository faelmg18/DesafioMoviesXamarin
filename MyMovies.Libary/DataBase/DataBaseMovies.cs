using MyMovies.Libary.Model.Fundation;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Libary.DataBase
{
    public class DataBaseMovies<T> : IDataBaseMovies<T> where T : EntitiePersistable, new()
    {
        public string DatabasePath { get; set; }
        private SQLiteConnection Database { get; set; }

        SQLiteConnection GetConnection()
        {
            if (Database != null)
                return Database;
            else
                return Database = new SQLiteConnection(DatabasePath);
        }

        public DataBaseMovies(string databasePath, bool storeDateTimeAsTicks = false)
        {
            try
            {
                DatabasePath = databasePath;
                Database = new SQLiteConnection(databasePath);
                CreateTables(typeof(Movie));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Delete(T data)
        {
            var db = GetConnection();
            try
            {
                BeginTransation(db);
                var response = db.Delete(data);
                CommitTransation(db);
                return response;
            }
            catch (Exception)
            {
                Rollback(db);
                throw;
            }

        }

        public int InsertOrUpdate(T data)
        {
            var db = GetConnection();
            try
            {
                BeginTransation(db);
                var response = db.InsertOrReplace(data);
                CommitTransation(db);
                return response;

            }
            catch (SQLiteException)
            {
                Rollback(db);
                throw;
            }
        }

        public int Insert(T data)
        {
            var db = GetConnection();
            try
            {
                BeginTransation(db);

                var response = db.Insert(data);
                CommitTransation(db);
                return response;

            }
            catch (SQLiteException)
            {
                Rollback(db);
                throw;
            }
        }

        public void CreateTables(params Type[] types)
        {
            var db = GetConnection();

            try
            {
                CreateTablesResult result = new CreateTablesResult();

                BeginTransation(db);
                foreach (Type type in types)
                {
                    int aResult = db.CreateTable(type);
                    result.Results[type] = aResult;
                }
                CommitTransation(db);
            }
            catch (Exception ex)
            {
                Rollback(db);
                throw ex;
            }

        }

        public T Find(T obj)
        {
            var db = GetConnection();
            return db.Find<T>(obj);
        }

        public T Find(long id)
        {
            var db = GetConnection();

            var element = db.Get<T>(id);
            return element;
        }

        public List<T> FindByQuery(string query)
        {
            var db = GetConnection();
            return db.Query<T>(query);
        }

        public List<T> FindAll()
        {
            var db = GetConnection();
            return db.Table<T>().ToList();
        }

        protected int Count()
        {
            var db = GetConnection();
            return db.Table<T>().Count();
        }

        private void BeginTransation(SQLiteConnection db)
        {
            try
            {
                db.BeginTransaction();
            }
            catch (Exception)
            {
                Rollback(db);
            }

        }

        private void CommitTransation(SQLiteConnection db)
        {
            db.Commit();
        }

        private void Rollback(SQLiteConnection db)
        {
            db.Rollback();
            db.Commit();
        }

    }
}
