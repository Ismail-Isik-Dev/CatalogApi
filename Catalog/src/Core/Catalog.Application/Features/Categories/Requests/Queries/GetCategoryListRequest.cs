using Catalog.Application.DTOs.Categories;
using Catalog.Application.Utilities.Result.Contract;
using MediatR;

namespace Catalog.Application.Features.Categories.Requests.Queries
{
    public class GetCategoryListRequest : IRequest<IDataResult<CategoryListDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Attributes { get; set; }
    }
}
