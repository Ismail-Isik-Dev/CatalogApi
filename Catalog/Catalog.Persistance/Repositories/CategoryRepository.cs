using Catalog.Application.Persistence.Contracts;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistance.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly CatalogDbContext _context;

        public CategoryRepository(CatalogDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category> CategoryByName(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
