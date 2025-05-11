using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class ProductOptionMap : IEntityTypeConfiguration<ProductOptionEntity>
{
    public void Configure(EntityTypeBuilder<ProductOptionEntity> builder)
    {
        builder.ToTable("ProductOption", "Product");
        builder.HasOne(o => o.Product)
            .WithMany(m => m.ProductOptions)
            .HasForeignKey(f => f.ProductId);


        builder.HasQueryFilter(f => f.IsDeleted == false);
    }
}
