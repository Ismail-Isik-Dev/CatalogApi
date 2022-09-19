using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistance.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.Status).HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);

            //builder.HasMany(x => x.Attributes).WithMany("Products").LeftNavigation.;
        }
    }
}
