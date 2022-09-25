using Catalog.Domain.Common;
using System.Text.Json.Serialization;

namespace Catalog.Domain.Entities
{
    public class Product : BaseDomainEntity, IEntity
    {
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ICollection<ProductAttribute> ProductAttributes { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
    }
}
