using Catalog.Application.Utilities.Result.Contract;
using MediatR;

namespace Catalog.Application.Features.Products.Requests.Commands
{
    public class DeleteProductCommand : IRequest<IResult>
    {
        public int Id { get; set; }
    }
}
