using System.Linq.Expressions;
using Leave_Management_System.Common;

namespace Leave_Management_System.Repositories.Interfaces;

public interface IRepository<T> where T : EntityBase
{
    IQueryable<T> GetAll();
    IQueryable<T> GetWhere(Expression<Func<T,bool>> predicate, CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(long id,CancellationToken cancellationToken = default);
    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T,bool>> predicate, CancellationToken cancellationToken = default);
    Task AddAsync(T entity,CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    void UpdateAsync(T entity);
    void UpdateRangeAsync(IEnumerable<T> entities);
    Task SoftDeleteAsync(long id, CancellationToken cancellationToken = default);
    void Remove(T entity);
    Task<bool> ExistsAsync(Expression<Func<T,bool>> predicate, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
