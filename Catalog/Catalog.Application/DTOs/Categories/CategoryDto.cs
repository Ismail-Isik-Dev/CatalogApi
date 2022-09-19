using Catalog.Application.DTOs.Common;
using System.ComponentModel;

namespace Catalog.Application.DTOs.Categories
{
    public class CategoryDto : BaseDto, ICategoryDto
    {
        public string Name { get; set; }
        public IList<CategoryAttribute> CategoryAttributes { get; set; }
    }
}
