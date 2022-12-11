using Catalog.Application.DTOs.Products;
using Catalog.Application.Utilities.Result.Contract;
using MediatR;

namespace Catalog.Application.Features.Products.Requests.Commands
{
    public class CreateProductCommand : IRequest<IDataResult<ProductDto>>
    {
        public ProductCreateDto Product { get; set; }
    }
}
