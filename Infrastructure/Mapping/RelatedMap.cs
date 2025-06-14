using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class RelatedMap : IEntityTypeConfiguration<RelatedEntity>
{
    public void Configure(EntityTypeBuilder<RelatedEntity> builder)
    {
        builder.ToTable("Related", "Product");
        builder.HasOne(o => o.Product)
            .WithMany(m => m.Relateds)
            .HasForeignKey(f => f.ProductId);
    }
}
