using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities;

namespace NLayer.Repository.Seeds
{
    internal class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(
                new ProductFeature() { Id = 1, Color = "Yeşil", Height = 2, Width = 4, ProductId = 1 },
                new ProductFeature() { Id = 2, Color = "Kırmızı", Height = 3, Width = 5, ProductId = 2 }
                );
        }
    }
}
