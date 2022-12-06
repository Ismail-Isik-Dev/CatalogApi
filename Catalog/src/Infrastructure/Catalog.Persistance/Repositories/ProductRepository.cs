using Catalog.Application.DTOs.Products;
using Catalog.Application.Persistence.Contracts;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Catalog.Persistance.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository 
    {
        private readonly CatalogDbContext _context;

        public ProductRepository(CatalogDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<ProductDto>> GetProductsWithAttributes(Expression<Func<Product, bool>> predicate)
        {
            var products = await _context.Products.Include(x => x.ProductAttributes).ThenInclude(x => x.Attribute).Where(predicate).ToListAsync();

            var productDtoList = new List<ProductDto>();

            foreach (var item in products)
            {
                var prdAttribute = item.ProductAttributes.FirstOrDefault();

                productDtoList.Add(new ProductDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    CategoryId = item.CategoryId,
                    CreatedDate = item.CreatedDate,
                    ModifiedDate = item.ModifiedDate,
                    Status = item.Status,
                    ProductAttributes = item.ProductAttributes.Select(x => new ProductAttributesDto
                    {
                        Name = x.Attribute.Name,
                        Value = x.Value,
                    })
                });
            }

            return productDtoList;
        }
    }
}
