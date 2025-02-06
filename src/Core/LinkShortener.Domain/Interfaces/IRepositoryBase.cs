using System.Linq.Expressions;

namespace LinkShortener.Domain.Interfaces;

public interface IRepositoryBase<T>
{
    Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Delete(T entity);
}