using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class EventMap :
    IEntityTypeConfiguration<EventEntity>
{
    public void Configure(EntityTypeBuilder<EventEntity> builder)
    {
        builder.ToTable("Event", "dbo");
        builder.HasQueryFilter(f => f.IsDeleted == false);
        builder.HasMany(m => m.Pictures)
            .WithOne(o => o.Event)
            .HasForeignKey(f => f.EventId);
        builder.HasMany(m => m.Videos)
    .WithOne(o => o.Event)
    .HasForeignKey(f => f.EventId);
    }
}
