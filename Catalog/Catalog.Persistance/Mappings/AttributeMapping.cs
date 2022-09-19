using Microsoft.EntityFrameworkCore;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistance.Mappings
{
    public class AttributeMapping : IEntityTypeConfiguration<Domain.Entities.Attribute>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Attribute> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();
            builder.Property(x => x.DisplayName).HasMaxLength(250).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.Status).HasColumnType("int").IsRequired();
        }
    }
}
