namespace Catalog.Application.DTOs.Products
{
    public class ProductCreateDto: IProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public List<ProductAttributesAddDto> Attributes { get; set; }
    }
}
