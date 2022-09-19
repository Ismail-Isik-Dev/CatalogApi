using Catalog.Domain.Common;

namespace Catalog.Domain.Entities
{
    public class Product : BaseDomainEntity, IEntity
    {
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ICollection<ProductAttribute> Attributes { get; set; }
        public Category Category { get; set; }
    }
}
