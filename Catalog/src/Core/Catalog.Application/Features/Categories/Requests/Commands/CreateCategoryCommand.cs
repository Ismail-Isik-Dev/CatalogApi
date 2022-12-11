using Catalog.Application.DTOs.Categories;
using Catalog.Application.Utilities.Result.Contract;
using MediatR;

namespace Catalog.Application.Features.Categories.Requests.Commands
{
    public class CreateCategoryCommand : IRequest<IDataResult<CategoryDto>>
    {
        public CategoryCreateDto Category { get; set; }
    }
}
