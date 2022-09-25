using Catalog.Application.DTOs.Products;
using Catalog.Domain.Entities;
using System.Linq.Expressions;

namespace Catalog.Application.Persistence.Contracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IList<ProductDto>> GetProductsWithAttributes(Expression<Func<Product, bool>> predicate);
    }
}
