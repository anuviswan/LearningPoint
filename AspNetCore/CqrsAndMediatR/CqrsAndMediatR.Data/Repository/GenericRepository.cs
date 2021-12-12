using CqrsAndMediatR.Data.Database;

namespace CqrsAndMediatR.Data.Repository;
public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
{
    protected readonly CustomerDbContext CustomerDbContext;

    public GenericRepository(CustomerDbContext customDbContext)
    {
        CustomerDbContext = customDbContext;
    }


    public IEnumerable<TEntity> GetAll()
    {
        try
        {
            return CustomerDbContext.Set<TEntity>();
        }
        catch (Exception ex)
        {
            throw new Exception($"Couldn't retrieve entities: {ex.Message}");
        }
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
        }

        try
        {
            await CustomerDbContext.AddAsync(entity);
            await CustomerDbContext.SaveChangesAsync();

            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
        }
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
        }

        try
        {
            CustomerDbContext.Update(entity);
            await CustomerDbContext.SaveChangesAsync();

            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"{nameof(entity)} could not be updated {ex.Message}");
        }
    }
}