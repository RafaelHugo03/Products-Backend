namespace Domain.Repositories
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}