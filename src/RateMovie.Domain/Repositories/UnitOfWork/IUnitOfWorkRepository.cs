namespace RateMovie.Domain.Repositories.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        Task Commit();
    }
}
