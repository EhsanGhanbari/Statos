using System;
using System.Collections.Generic;

namespace Statos.Model
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T FindBy(params Object[] keyValues);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}

