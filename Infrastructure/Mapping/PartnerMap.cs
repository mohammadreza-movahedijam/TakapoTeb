using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class PartnerMap :
    IEntityTypeConfiguration<PartnerEntity>
{
    public void Configure(EntityTypeBuilder<PartnerEntity> builder)
    {
        builder.ToTable("Partner", "dbo");
        builder.HasQueryFilter(f => f.IsDeleted == false);
    }
}
