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

            builder.HasOne(x => x.Category)
                .WithMany(x => x.CategoryAttributes)
                .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Attribute)
                .WithMany(x => x.CategoryAttributes)
                .HasForeignKey(x => x.AttributeId);

            builder.ToTable("CategoryAttribute");

            // CategoryAttribute table data initializer...

            builder.HasData(
                new CategoryAttribute
                {
                    AttributeId = 1,
                    CategoryId = 1,
                },
                new CategoryAttribute
                {
                    AttributeId = 2,
                    CategoryId = 1,
                },
                new CategoryAttribute
                {
                    AttributeId = 2,
                    CategoryId = 2,
                },
                new CategoryAttribute
                {
                    AttributeId = 2,
                    CategoryId = 4,
                },
                new CategoryAttribute
                {
                    AttributeId = 3,
                    CategoryId = 3,
                },
                new CategoryAttribute
                {
                    AttributeId = 4,
                    CategoryId = 4,
                },
                new CategoryAttribute
                {
                    AttributeId = 1,
                    CategoryId = 4,
                },
                new CategoryAttribute
                {
                    AttributeId = 2,
                    CategoryId = 3,
                }
            );
        }
    }
}
