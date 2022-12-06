using Catalog.Application.DTOs.Categories;
using Catalog.Application.Persistence.Contracts;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<IList<CategoryDto>> GetCategoriesWithAttributes(Expression<Func<Category, bool>> predicate)
        {
            var categories = await _context.Categories.Include(x => x.CategoryAttributes).ThenInclude(x => x.Attribute).Where(predicate).ToListAsync();

            var categoryListDto = new List<CategoryDto>();

            foreach (var item in categories)
            {
                categoryListDto.Add(new CategoryDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Status = item.Status,
                    CreatedDate = item.CreatedDate,
                    ModifiedDate = item.ModifiedDate,
                    CategoryAttributes = item.CategoryAttributes.Select(x => x.Attribute.Name)
                });
            }

            return categoryListDto;
        }
    }
}
