using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByCpf(string cpf);
        User GetUserByEmail(string email);
    }
}