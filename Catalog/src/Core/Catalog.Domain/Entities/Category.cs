using Catalog.Domain.Common;
using System.Text.Json.Serialization;

namespace Catalog.Domain.Entities
{
    public class Category : BaseDomainEntity, IEntity
    {
        // TestComment
        public ICollection<CategoryAttribute> CategoryAttributes { get; set; }

        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}
