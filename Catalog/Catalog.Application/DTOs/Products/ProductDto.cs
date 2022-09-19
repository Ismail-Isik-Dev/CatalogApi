using Catalog.Application.DTOs.Common;
using Catalog.Domain.Entities;

namespace Catalog.Application.DTOs.Products
{
    public class ProductDto : BaseDto, IProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ICollection<ProductAttribute> Attributes { get; set; }

        public Category Category { get; set; }
    }
}
