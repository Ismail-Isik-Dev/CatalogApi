using Catalog.Application.DTOs.Common;
using Catalog.Domain.Common;

namespace Catalog.Application.DTOs.Products
{
    public class ProductDto : BaseDto, IProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
        public IEnumerable<ProductAttributesDto> ProductAttributes { get; set; }
    }
}
