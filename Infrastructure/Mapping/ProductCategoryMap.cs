﻿using Domain.Entities.Product;
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
    IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.HasQueryFilter(f=>f.IsDeleted==false);
        builder.ToTable("Category", "Product");
        builder.Property(p=>p.DisplayPriority).HasDefaultValue(0);
        builder.Property(p => p.TitleEn).HasMaxLength(500);
        builder.Property(p => p.TitleFa).HasMaxLength(500);
        builder.Property(p => p.DescriptionEn).HasMaxLength(6000);
        builder.Property(p => p.DescriptionFa).HasMaxLength(6000);
        builder.HasOne(x => x.ParentCategory)
              .WithMany(x => x.SubCategories)
              .HasForeignKey(x => x.ParentProductCategoryId)
              .IsRequired(false)
              .OnDelete(DeleteBehavior.Restrict);
    }
}
