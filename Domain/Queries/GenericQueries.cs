using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Queries
{
    public class GenericQueries<T> where T : BaseEntity
    {
        public static Expression<Func<T, bool>> GetById(Guid id)
        {
            return c => c.Id == id;
        }
    }
}