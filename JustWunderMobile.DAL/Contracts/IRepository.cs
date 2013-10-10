using System;
using System.Collections.Generic;

namespace JustWunderMobile.DAL.Contracts
{
    public interface IRepository<T> where T : class, new()
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        IEnumerable<T> GetAll(bool withReferences);

        T GetById(int id);

        void DeleteAll();
    }
}