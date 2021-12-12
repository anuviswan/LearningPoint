using CqrsAndMediatR.Data.Database;

namespace CqrsAndMediatR.Data.Repository;
public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class,IEntity,new()
{
    protected readonly CustomerDbContext CustomerDbContext;

    public GenericRepository(CustomerDbContext customDbContext) => CustomerDbContext = customDbContext;

    public IEnumerable<TEntity> GetAll() => CustomerDbContext.Set<TEntity>();

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await CustomerDbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await CustomerDbContext.AddAsync(entity);
        await CustomerDbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        CustomerDbContext.Update(entity);
        await CustomerDbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var itemToRemove = CustomerDbContext.Set<TEntity>().FindAsync(entity.Id);
        CustomerDbContext.Remove(itemToRemove);
        await CustomerDbContext.SaveChangesAsync();
        return entity;
    }

   
}