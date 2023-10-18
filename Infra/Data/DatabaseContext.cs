using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class DatabaseContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected DatabaseContext(){}
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
        }

        public bool Commit()
        {
            var success = SaveChanges() > 0;

            return success;
        }
    }
}