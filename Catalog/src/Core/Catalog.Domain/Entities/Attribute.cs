using Catalog.Domain.Common;
using System.Text.Json.Serialization;

namespace Catalog.Domain.Entities
{
    public class Attribute: BaseDomainEntity, IEntity
    {
        public string DisplayName { get; set; }
        [JsonIgnore]
        public ICollection<CategoryAttribute> CategoryAttributes { get; set; }

        [JsonIgnore]
        public ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
