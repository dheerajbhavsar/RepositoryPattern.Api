using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Api.Core.Repositories;
using System.Linq.Expressions;

namespace RepositoryPattern.Api;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    public Repository(DbContext context)
    {
        _entities = context?.Set<TEntity>();
        Context = context;
    }

    private readonly DbSet<TEntity>? _entities;
    
    protected DbContext Context { get; }

    public async Task Add(TEntity entity)
    {
        await _entities.AddAsync(entity);
    }

    public async Task AddRange(IEnumerable<TEntity> entities)
    {
        await _entities.AddRangeAsync(entities);
    }

    public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return await _entities.Where(predicate).ToListAsync();
    }

    public async Task<TEntity> Get(int id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _entities.ToListAsync();
    }

    public void Remove(TEntity entity)
    {
        _entities.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _entities.RemoveRange(entities);
    }

    public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return await _entities.SingleOrDefaultAsync(predicate);
    }
}