using Catalog.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistance.Mappings
{
    public class AttributeMapping : IEntityTypeConfiguration<Domain.Entities.Attribute>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Attribute> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.DisplayName)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.Property(x => x.ModifiedDate)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("int")
                .IsRequired();

            builder.ToTable("Attributes");

            // Attributes table data initializer...

            builder.HasData(
                new Domain.Entities.Attribute
                {
                    Id = 1,
                    Name = "Gender",
                    DisplayName = "Cinsiyet",
                    Status = Status.Active,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Domain.Entities.Attribute
                {
                    Id = 2,
                    Name = "Size",
                    DisplayName = "Boyut",
                    Status = Status.Active,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Domain.Entities.Attribute
                {
                    Id = 3,
                    Name = "Color",
                    DisplayName = "Renk",
                    Status = Status.Active,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Domain.Entities.Attribute
                {
                    Id = 4,
                    Name = "Brand",
                    DisplayName = "Marka",
                    Status = Status.Active,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            );
        }
    }
}
