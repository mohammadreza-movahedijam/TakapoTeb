using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class OptionMap : IEntityTypeConfiguration<OptionEntity>
{
    public void Configure(EntityTypeBuilder<OptionEntity> builder)
    {
        builder.ToTable("Option", "Product");
        builder.HasOne(o => o.Product)
            .WithMany(m => m.Options)
            .HasForeignKey(f => f.ProductId);


        builder.HasQueryFilter(f => f.IsDeleted == false);
    }
}
