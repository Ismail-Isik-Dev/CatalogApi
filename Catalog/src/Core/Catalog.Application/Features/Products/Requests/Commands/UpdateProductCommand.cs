using Catalog.Application.DTOs.Products;
using MediatR;

namespace Catalog.Application.Features.Products.Requests.Commands
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public ProductUpdateDto Product { get; set; }
    }
}
