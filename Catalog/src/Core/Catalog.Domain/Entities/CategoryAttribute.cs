using System.Text.Json.Serialization;

namespace Catalog.Domain.Entities
{
    public class CategoryAttribute
    {
        [JsonIgnore]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public int AttributeId { get; set; }
        public Attribute Attribute { get; set; }
    }
}
