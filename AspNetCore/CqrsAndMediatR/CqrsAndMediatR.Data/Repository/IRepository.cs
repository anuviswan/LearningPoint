namespace CqrsAndMediatR.Data.Repository;
public interface IRepository<TEntity> where TEntity : class, IEntity, new()
{
    IEnumerable<TEntity> GetAll();
    Task<TEntity> GetByIdAsync(long id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
}