using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class ImageMap :
    IEntityTypeConfiguration<ImageEntity>
{
    public void Configure(EntityTypeBuilder<ImageEntity> builder)
    {
        builder.ToTable("Image", "Product");
        builder.HasQueryFilter(f => f.IsDeleted == false);
        builder.HasOne(o => o.Product)
         .WithMany(m => m.Images)
         .HasForeignKey(f => f.ProductId);

    }
}
