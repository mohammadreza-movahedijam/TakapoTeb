using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class CatalogMap :
    IEntityTypeConfiguration<CatalogEntity>
{
    public void Configure(EntityTypeBuilder<CatalogEntity> builder)
    {
        builder.ToTable("Catalog");
        builder.HasQueryFilter(f => f.IsDeleted == false);
    }
}
