namespace CqrsAndMediatR.Data.Repository;
public interface IRepository<TEntity> where TEntity : class, new()
{
    IEnumerable<TEntity> GetAll();
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}