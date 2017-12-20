using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Interfaces
{
    public interface IRepository<T>
    {
        IReadOnlyList<T> GetAll();
        void Create(T entity);
        void Delete(Guid entityId);
        void Edit(T entity);
        T GetById(Guid entityId);
    }
}
