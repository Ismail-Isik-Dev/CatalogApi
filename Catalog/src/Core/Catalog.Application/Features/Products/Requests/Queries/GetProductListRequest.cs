using Catalog.Application.DTOs.Products;
using Catalog.Application.Utilities.Result.Contract;
using MediatR;

namespace Catalog.Application.Features.Products.Requests.Queries
{
    public class GetProductListRequest : IRequest<IDataResult<ProductListDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public string[] Attributes { get; set; }
    }
}
