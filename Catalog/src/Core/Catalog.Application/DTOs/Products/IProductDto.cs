namespace Catalog.Application.DTOs.Products
{
    public interface IProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
