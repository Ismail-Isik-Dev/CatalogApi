using Catalog.Application.DTOs.Common;

namespace Catalog.Application.DTOs.Products
{
    public class ProductDto : BaseDto, IProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
