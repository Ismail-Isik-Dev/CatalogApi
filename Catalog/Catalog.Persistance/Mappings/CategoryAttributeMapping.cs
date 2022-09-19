using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Attribute = Catalog.Domain.Entities.Attribute;

namespace Catalog.Persistance.Mappings
{
    public class CategoryAttributeMapping : IEntityTypeConfiguration<Domain.Entities.CategoryAttribute>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.CategoryAttribute> builder)
        {
            builder.HasKey(x => new { x.CategoryId, x.AttributeId });

            builder.HasOne(x => x.Category).WithMany(x => x.CategoryAttributes).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.Attribute).WithMany(x => x.CategoryAttributes).HasForeignKey(x => x.AttributeId);
        }
    }
}
