using Catalog.Application.Persistence.Contracts;

namespace Catalog.Persistance.Repositories
{
    public class AttributeRepository : GenericRepository<Domain.Entities.Attribute>, IAttributeRepository
    {
        private readonly CatalogDbContext _context;

        public AttributeRepository(CatalogDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
