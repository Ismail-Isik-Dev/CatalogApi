using Catalog.Domain.Common;
using System.Text.Json.Serialization;

namespace Catalog.Domain.Entities
{
    public class Attribute: BaseDomainEntity
    {
        public string DisplayName { get; set; }

        //public ICollection<ProductAttribute> Products { get; set; }
        [JsonIgnore]
        public IList<CategoryAttribute> CategoryAttributes { get; set; }
    }
}
