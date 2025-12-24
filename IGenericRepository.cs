namespace AuthHub.Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
    }
}