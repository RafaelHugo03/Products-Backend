using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DatabaseContext db;
        private readonly DbSet<User> dbset;
        public UserRepository(DatabaseContext db) : base(db)
        {
            dbset = db.Set<User>();
        }

        public User GetUserByCpf(string cpf)
        {
            return dbset.AsNoTracking().Where(UserQueries.GetByCpf(cpf)).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return dbset.AsNoTracking().Where(UserQueries.GetByEmail(email)).FirstOrDefault();
        }
    }
}