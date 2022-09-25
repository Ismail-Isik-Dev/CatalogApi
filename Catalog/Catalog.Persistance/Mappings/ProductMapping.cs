using Catalog.Domain.Common;
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

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.Property(x => x.ModifiedDate)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            // Product table data initializer...

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Test Product_1",
                    Price = 50,
                    CategoryId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Status = Status.Active
                },
                 new Product
                 {
                     Id = 2,
                     Name = "Test Product_2",
                     Price = 100,
                     CategoryId = 2,
                     CreatedDate = DateTime.Now,
                     ModifiedDate = DateTime.Now,
                     Status = Status.Active
                 },
                  new Product
                  {
                      Id = 3,
                      Name = "Test Product_3",
                      Price = 150,
                      CategoryId = 3,
                      CreatedDate = DateTime.Now,
                      ModifiedDate = DateTime.Now,
                      Status = Status.Active
                  },
                   new Product
                   {
                       Id = 4,
                       Name = "Test Product_4",
                       Price = 200,
                       CategoryId = 4,
                       CreatedDate = DateTime.Now,
                       ModifiedDate = DateTime.Now,
                       Status = Status.Active
                   }
            );
        }
    }
}
