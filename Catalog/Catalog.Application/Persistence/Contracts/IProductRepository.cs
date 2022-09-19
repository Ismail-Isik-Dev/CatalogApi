using Catalog.Domain.Entities;

namespace Catalog.Application.Persistence.Contracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        // Write custom operation...
    }
}
