using Catalog.Application.DTOs.Categories;
using Catalog.Domain.Entities;
using System.Linq.Expressions;

namespace Catalog.Application.Persistence.Contracts
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> CategoryByName(string name);
        Task<IList<CategoryDto>> GetCategoriesWithAttributes(Expression<Func<Category, bool>> predicate);
    }
}
