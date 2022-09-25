using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistance.Mappings
{
    public class ProductAttributeMapping : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.AttributeId });

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductAttributes)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Attribute)
                .WithMany(x => x.ProductAttributes)
                .HasForeignKey(x => x.AttributeId);

            builder.Property(x => x.Value)
                .HasMaxLength(150)
                .IsRequired();

            builder.ToTable("ProductAttribute");

            // ProductAttribute table data initializer...

            builder.HasData(
                new ProductAttribute
                {
                    ProductId = 1,
                    AttributeId = 1,
                    Value = "Erkek"
                },
                new ProductAttribute
                {
                    ProductId = 1,
                    AttributeId = 2,
                    Value = "XXL"
                },
                 new ProductAttribute
                 {
                     ProductId = 2,
                     AttributeId = 2,
                     Value = "M"
                 },
                 new ProductAttribute
                 {
                     ProductId = 3,
                     AttributeId = 2,
                     Value = "L"
                 },
                 new ProductAttribute
                 {
                     ProductId = 3,
                     AttributeId = 3,
                     Value = "Mavi"
                 },
                 new ProductAttribute
                 {
                     ProductId = 4,
                     AttributeId = 1,
                     Value = "Bayan"
                 },
                 new ProductAttribute
                 {
                     ProductId = 4,
                     AttributeId = 4,
                     Value = "Test Brand"
                 }
            );
        }
    }
}
