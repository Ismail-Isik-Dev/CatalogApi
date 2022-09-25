using Catalog.Application.DTOs.Categories;
using MediatR;

namespace Catalog.Application.Features.Categories.Requests.Queries
{
    public class GetCategoryListRequest : IRequest<CategoryListDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Attributes { get; set; }
    }
}
