using Catalog.Domain.Common;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistance.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.Property(x => x.ModifiedDate)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("int")
                .IsRequired();

            builder.ToTable("Categories");

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Smart Phone",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Status = Status.Active
                },
                new Category
                {
                    Id = 2,
                    Name = "Computer",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Status = Status.Active
                },
                new Category
                {
                    Id = 3,
                    Name = "Tablet",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Status = Status.Active,
                },
                new Category
                {
                    Id = 4,
                    Name = "Boiler",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Status = Status.Active
                }
            );

        }
    }
}
