using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext Db;
        private readonly DbSet<T> DbSet;

        public BaseRepository(DatabaseContext db)
        {
            this.Db = db;
            DbSet = db.Set<T>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public virtual void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(Guid id)
        {
            var entity = GetById(id);
            DbSet.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            DbSet.Update(entity);
        }

        public virtual List<T> GetAll()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public virtual T GetById(Guid id)
        {
            return DbSet.AsNoTracking().Where(GenericQueries<T>.GetById(id)).FirstOrDefault();
        }
    }
}