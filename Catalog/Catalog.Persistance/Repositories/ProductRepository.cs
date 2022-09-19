using Catalog.Application.Persistence.Contracts;
using Catalog.Domain.Entities;

namespace Catalog.Persistance.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository 
    {
        private readonly CatalogDbContext _context;

        public ProductRepository(CatalogDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
