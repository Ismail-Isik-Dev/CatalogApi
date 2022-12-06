using Catalog.Domain.Entities;

namespace Catalog.Application.DTOs.Categories
{
    public class CategoryCreateDto : ICategoryDto
    {
        public string Name { get; set; }
        public List<CategoryAttributesAddDto> CategoryAttributes { get; set; }
    }
}
