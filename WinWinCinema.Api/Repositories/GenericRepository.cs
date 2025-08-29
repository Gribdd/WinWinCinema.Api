using System.Linq.Expressions;
using WinWinCinema.Api.Domain.Common;
using WinWinCinema.Api.Repositories.Interfaces;

namespace WinWinCinema.Api.Repositories;

/// <summary>
/// A generic repository implementation for performing CRUD operations on entities.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
    /// </summary>
    /// <param name="context">The database context to be used by the repository.</param>
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    /// <summary>
    /// Retrieves an entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity.</param>
    /// <returns>The entity if found; otherwise, null.</returns>
    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    /// <summary>
    /// Retrieves all entities of the specified type.
    /// </summary>
    /// <returns>A collection of all entities.</returns>
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    /// <summary>
    /// Adds a new entity to the database.
    /// </summary>
    /// <param name="item">The entity to add.</param>
    public async Task AddAsync(TEntity item)
    {
        _dbSet.Add(item);
    }

    /// <summary>
    /// Updates an existing entity in the database.
    /// </summary>
    /// <param name="item">The entity to update.</param>
    public async Task UpdateAsync(TEntity item)
    {
        _context.Entry(item).State = EntityState.Modified;
    }

    /// <summary>
    /// Deletes an entity from the database.
    /// </summary>
    /// <param name="item">The entity to delete.</param>
    public async Task DeleteAsync(TEntity item)
    {
        _dbSet.Remove(item);
    }

    public async Task<IEnumerable<TEntity>> GetAllWithIncludesAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }

    public async Task<TEntity?> GetByIdWithIncludesAsync(
        int id,
        params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet; 

        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
    }
}