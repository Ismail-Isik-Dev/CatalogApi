using Catalog.Application.DTOs.Categories;
using MediatR;

namespace Catalog.Application.Features.Categories.Requests.Commands
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public CategoryCreateDto Category { get; set; }
    }
}
