using Microsoft.EntityFrameworkCore;
using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Mapping;

internal sealed class ProductMap : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("Product", "Product");
        builder.Property(p => p.ImageHeaderPath).HasDefaultValue("default.jpg");
        builder.Property(p=>p.TitleEn).IsRequired().HasMaxLength(700);
        builder.Property(p=>p.TitleFa).IsRequired().HasMaxLength(700);
        builder.Property(p=>p.DescrptionEn).IsRequired();
        builder.Property(p=>p.DescrptionFa).IsRequired();
        builder.HasOne(o => o.Category)
            .WithMany(m => m.Products)
            .HasForeignKey(f => f.CategoryId);
        builder.HasQueryFilter(f=>f.IsDeleted==false);
    }
}
