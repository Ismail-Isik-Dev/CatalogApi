using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistance.Mappings
{
    public class ProductAttributeMapping : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.HasKey("ProductId", "AttributeId");

            //builder.HasOne(x => x.Product).WithMany(x => x.Attributes).HasForeignKey(x => x.ProductId);

            //builder.HasOne(x => x.Attribute).WithMany(x=>x.Products).HasForeignKey(x=>x.AttributeId);

            builder.Property(x => x.Value).HasMaxLength(150).IsRequired();
        }
    }
}
