using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> GetByCpf(string cpf)
        {
            return c => c.Cpf == cpf;
        }

        public static Expression<Func<User, bool>> GetByEmail(string email)
        {
            return c => c.Email == email;
        }
    }
}