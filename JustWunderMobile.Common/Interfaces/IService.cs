using System;
using System.Collections.Generic;

namespace JustWunderMobile.Common.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> Read(Func<T, bool> predicate);
        bool Update(T modelToUpdate);
        bool Remove(T modelToRemove);
    }
}
