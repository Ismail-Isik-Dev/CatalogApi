using Catalog.Domain.Common;
using System.ComponentModel;

namespace Catalog.Domain.Entities
{
    public class Category : BaseDomainEntity, IEntity
    {
        public IList<CategoryAttribute> CategoryAttributes { get; set; }
    }
}
