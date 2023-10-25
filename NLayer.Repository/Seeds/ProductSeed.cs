using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, CategoryId = 1, Name = "Renaut",  Price = 100, Stock= 20, CreatedDate = DateTime.Now },
                new Product { Id = 2, CategoryId = 1, Name = "Peugeot",  Price = 200, Stock= 40, CreatedDate = DateTime.Now },
                new Product { Id = 3, CategoryId = 1, Name = "Volkwagen",  Price = 300, Stock= 50, CreatedDate = DateTime.Now },
                new Product { Id = 4, CategoryId = 2, Name = "Ford",  Price = 800, Stock= 60, CreatedDate = DateTime.Now },
                new Product { Id = 5, CategoryId = 3, Name = "Setra",  Price = 60, Stock= 10, CreatedDate = DateTime.Now }
                );
        }
    }
}
