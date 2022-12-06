using Catalog.Domain.Entities;

namespace Catalog.Application.DTOs.Categories
{
    public class CategoryListDto
    {
        public IList<CategoryDto> Categories { get; set; }
    }
}
