using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IUnitOfWork UnitOfWork { get; }
        void Create(T entity);
        void Edit(T entity);
        void Delete(Guid id);
        List<T> GetAll();
        T GetById(Guid  id);
    }
}