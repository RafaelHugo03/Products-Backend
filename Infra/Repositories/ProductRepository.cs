using Domain.Entities;
using Domain.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DbSet<Product> Dbset;
        public ProductRepository(DatabaseContext db) : base(db)
        {
            this.Dbset = db.Set<Product>();
        }

        public override List<Product> GetAll()
        {
            return Dbset.AsNoTracking().Include(p => p.User).ToList();
        }
    }
}