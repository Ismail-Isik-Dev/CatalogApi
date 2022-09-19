using Catalog.Domain.Entities;

namespace Catalog.Application.DTOs.Categories
{
    public class CategoryListDto
    {
        public IList<Category> Categories { get; set; }
    }
}
