using Catalog.Application.DTOs.Products;
using MediatR;

namespace Catalog.Application.Features.Products.Requests.Queries
{
    public class GetProductListRequest : IRequest<ProductListDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public string[] Attributes { get; set; }
    }
}
