using System.Collections.Generic;
using JustWunderMobile.DAL.Contracts;
using OpenNETCF.ORM;

namespace JustWunderMobile.DAL.Repositories
{
    /// <summary>
    /// Generic repository for all entities of local database
    /// </summary>
    /// <typeparam name="T">Entity model</typeparam>
    public abstract class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        #region Properties
        protected SQLStoreBase<SqlEntityInfo> Store { get; set; }
        #endregion

        #region Constructors
        protected BaseRepository(SQLStoreBase<SqlEntityInfo> store)
        {
            Store = store;
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

        public IEnumerable<T> GetAll(bool withReferences)
        {
            return Store.Select<T>(withReferences);
        }

        public T GetById(int id)
        {
            return Store.Select<T>(id);
        }

        public void DeleteAll()
        {
            Store.Delete<T>();
        }

        #endregion
    }
}