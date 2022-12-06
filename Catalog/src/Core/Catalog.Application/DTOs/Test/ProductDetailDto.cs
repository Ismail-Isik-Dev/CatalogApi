using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.DTOs.Test
{
    internal class ProductDetailDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int CategoryId { get; set; }

        public List<ProductAttributeDto> Attributes { get; set; }
    }

    public class ProductAttributeDto
    {
        public AttributeDto Attribute { get; set; }
        public string Value { get; set; }
    }


    public class AttributeDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
