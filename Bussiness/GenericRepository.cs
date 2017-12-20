using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Domain.Interfaces;
using Data.Persistance;

namespace Bussiness
{
    public class GenericRepository<T> : IRepository<T> where T: class
    {

        private readonly DatabaseContext _databaseContext;

        public GenericRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IReadOnlyList<T> GetAll()
        {

            return _databaseContext.Set<T>().ToList(); 
        }

        public void Create(T entity)
        {
            _databaseContext.Set<T>().Add(entity);
            _databaseContext.SaveChanges();
        }

        public void Delete(Guid entityId)
        {
            var entity = GetById(entityId);
            _databaseContext.Set<T>().Remove(entity);
            _databaseContext.SaveChanges();
        }

        public void Edit(T entity)
        {
            _databaseContext.Set<T>().Update(entity);
            _databaseContext.SaveChanges();
        }

        public T GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }
    }
}