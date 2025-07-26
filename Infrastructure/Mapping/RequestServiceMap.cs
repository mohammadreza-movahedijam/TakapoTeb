using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class RequestServiceMap :
    IEntityTypeConfiguration<RequestServiceEntity>
{
    public void Configure(EntityTypeBuilder<RequestServiceEntity> builder)
    {
        builder.ToTable("RequestService");
        builder.HasMany(m => m.RequestServiceAttaches)
            .WithOne(o => o.RequestService)
            .HasForeignKey(f => f.RequestServiceId);
    }
}
