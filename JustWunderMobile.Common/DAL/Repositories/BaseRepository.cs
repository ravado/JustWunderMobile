using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Plugins.Sqlite;
using JustWunderMobile.Common.DAL.Contracts;

namespace JustWunderMobile.Common.DAL.Repositories
{
    /// <summary>
    /// Generic repository for all entities of local database
    /// </summary>
    /// <typeparam name="T">Entity model</typeparam>
    public abstract class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        public const string DATABASE_NAME = "jokes.db";

        #region Properties
        protected ISQLiteConnection Store { get; private set; }
        #endregion

        #region Constructors
        protected BaseRepository(ISQLiteConnectionFactory factory)
        {
            Store = factory.Create(DATABASE_NAME);
        }
        #endregion

        #region IRepository<T> Members

        public void Insert(T entity)
        {
            Store.Insert(entity);
        }

        public void Update(T entity)
        {
            Store.Update(entity);
        }

        public void Delete(T entity)
        {
            Store.Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return Store.Table<T>().AsEnumerable();
        }

        public T GetById(int id)
        {
            return Store.Get<T>(id);
        }

        public void DeleteAll()
        {
            Store.DropTable<T>();
        }

        #endregion
    }
}