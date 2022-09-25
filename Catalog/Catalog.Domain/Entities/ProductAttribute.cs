using System.Text.Json.Serialization;

namespace Catalog.Domain.Entities
{
    public class ProductAttribute
    {
        [JsonIgnore]
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Attribute Attribute { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; }
    }
}
