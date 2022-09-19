using Catalog.Application.DTOs.Categories;
using MediatR;

namespace Catalog.Application.Features.Categories.Requests.Queries
{
    public class GetCategoryListRequest : IRequest<CategoryListDto>
    {
        public string Name { get; set; }
        public int[] Attributes { get; set; }
    }
}
