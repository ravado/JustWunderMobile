using System.Collections.Generic;
using System.Linq;
using JustWunderMobile.Common.Interfaces;
using JustWunderMobile.DAL.Contracts;

namespace JustWunderMobile.Common.Services
{
    public abstract class BaseService<T, TEntity>: IService<T> where TEntity : class, new()
    {
        protected IRepository<TEntity> Repository { get; set; }

        protected BaseService(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public abstract IEnumerable<T> Read(System.Func<T, bool> predicate);
        public abstract bool Update(T modelToUpdate);
        public abstract bool Remove(T modelToRemove);
    }
}