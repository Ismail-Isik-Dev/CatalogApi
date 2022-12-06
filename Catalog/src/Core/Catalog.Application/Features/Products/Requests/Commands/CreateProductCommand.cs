using Catalog.Application.DTOs.Products;
using MediatR;

namespace Catalog.Application.Features.Products.Requests.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public ProductCreateDto Product { get; set; }
    }
}
