using Catalog.Domain.Common;

namespace Catalog.Domain.Entities
{
    public class Category : BaseDomainEntity, IEntity
    {
        public IList<CategoryAttribute> CategoryAttributes { get; set; }
    }
}
