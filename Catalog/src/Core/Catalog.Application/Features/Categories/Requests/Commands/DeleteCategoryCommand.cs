using Catalog.Application.Utilities.Result.Contract;
using MediatR;

namespace Catalog.Application.Features.Categories.Requests.Commands
{
    public class DeleteCategoryCommand : IRequest<IResult>
    {
        public int Id { get; set; }
    }
}
