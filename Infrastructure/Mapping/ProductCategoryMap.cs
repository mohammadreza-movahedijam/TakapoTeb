using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Infrastructure.Mapping;

internal sealed class ProductCategoryMap :
    IEntityTypeConfiguration<ProductCategoryEntity>
{
    public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
    {
        builder.ToTable("Category", "Product");
        builder.Property(p => p.TitleEn).HasMaxLength(500);
        builder.Property(p => p.TitleFa).HasMaxLength(500);
        builder.Property(p => p.DescriptionEn).HasMaxLength(6000);
        builder.Property(p => p.DescriptionFa).HasMaxLength(6000);
        builder.HasOne(x => x.ParentProductCategory)
              .WithMany(x => x.SubProductCategories)
              .HasForeignKey(x => x.ParentProductCategoryId)
              .IsRequired(false)
              .OnDelete(DeleteBehavior.Restrict);
    }
}
