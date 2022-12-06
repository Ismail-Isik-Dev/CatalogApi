using MediatR;

namespace Catalog.Application.Features.Products.Requests.Commands
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
