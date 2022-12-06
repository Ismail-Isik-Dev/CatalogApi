using Catalog.Domain.Entities;

namespace Catalog.Application.DTOs.Products
{
    public class ProductListDto
    {
        public IList<ProductDto> Products { get; set; }
    }
}
