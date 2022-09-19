namespace Catalog.Application.DTOs.Products
{
    public class ProductCreateDto: IProductDto
    {
        // TODD: Attributes will be added...
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
