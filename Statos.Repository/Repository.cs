using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using Statos.Model;

namespace Statos.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {

        private readonly DbSet<T> _entitySet;
        private readonly StatosContext _statosContext;


        public Repository(StatosContext statosContext)
        {
            _statosContext = statosContext;
            _entitySet = statosContext.Set<T>();
        }


        public IEnumerable<T> GetAll()
        {
            try
            {
                return _entitySet;
            }
            catch (Exception exception)
            {
                  // catch
            }
            return _entitySet;
        }


        public T FindBy(params Object[] keyValues)
        {
            return _entitySet.Find(keyValues);
        }


        public void Add(T entity)
        {
            _entitySet.Add(entity);
        }


        public void Update(T entity)
        {
            _entitySet.Attach(entity);
            _statosContext.Entry(entity).State=EntityState.Modified;
        }


        public void Delete(T entity)
        {
            var e = _statosContext.Entry(entity);
            if (e.State == EntityState.Detached)
            {
                _statosContext.Set<T>().Attach(entity);
                e = _statosContext.Entry(entity);
            }
            e.State=EntityState.Deleted;    
        }

        public void SaveChanges()
        {
            _statosContext.SaveChanges();
        }
    }
}


