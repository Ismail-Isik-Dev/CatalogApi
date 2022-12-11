using Catalog.Application.DTOs.Categories;
using Catalog.Application.Utilities.Result.Contract;
using MediatR;

namespace Catalog.Application.Features.Categories.Requests.Commands
{
    public class UpdateCategoryCommand : IRequest<IResult>
    {
        public CategoryUpdateDto Category { get; set; }
    }
}
