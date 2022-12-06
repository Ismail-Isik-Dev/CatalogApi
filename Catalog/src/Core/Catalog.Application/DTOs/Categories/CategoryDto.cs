using Catalog.Application.DTOs.Common;
using Catalog.Domain.Common;

namespace Catalog.Application.DTOs.Categories
{
    public class CategoryDto : BaseDto, ICategoryDto
    {
        public string Name { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public IEnumerable<string> CategoryAttributes { get; set; }
    }
}
