using Catalog.Application.DTOs.Categories;
using MediatR;

namespace Catalog.Application.Features.Categories.Requests.Commands
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public CategoryUpdateDto Category { get; set; }
    }
}
