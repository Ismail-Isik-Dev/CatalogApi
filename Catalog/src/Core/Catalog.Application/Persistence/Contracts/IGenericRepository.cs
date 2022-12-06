using Catalog.Domain.Common;
using System.Linq.Expressions;

namespace Catalog.Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class, IEntity , new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includedProperties);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includedProperties);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
