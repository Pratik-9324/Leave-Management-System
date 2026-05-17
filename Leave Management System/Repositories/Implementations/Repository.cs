using System.Linq.Expressions;
using Leave_Management_System.Common;
using Leave_Management_System.Data;
using Leave_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Leave_Management_System;

public class Repository<T> : IRepository<T> where T : EntityBase
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;
    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public IQueryable<T> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }
    public IQueryable<T> GetWhere(Expression<Func<T,bool>> predicate, CancellationToken cancellationToken = default)
    {
        return _dbSet.Where(predicate).AsNoTracking().AsQueryable();
    }
    public async Task<T?> GetByIdAsync(long id ,CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id ,cancellationToken);
    }
    public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T,bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate,cancellationToken);
    }
    public async Task<bool> ExistsAsync(Expression<Func<T,bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(predicate,cancellationToken);
    }
    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity,cancellationToken);
    }
    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddRangeAsync(entities,cancellationToken);
    }
    public void UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
    }
    public void UpdateRangeAsync(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }
    public async Task SoftDeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        T? entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
        if(entity == null)
        {
            return;
        }
        entity.IsDeleted = true;
        entity.IsActive = false;
        entity.UpdatedAt = DateTime.UtcNow;
        _dbSet.Update(entity);
    }
    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
