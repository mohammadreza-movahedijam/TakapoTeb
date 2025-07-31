using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class SliderMap : IEntityTypeConfiguration<SliderEntity>
{
    public void Configure(EntityTypeBuilder<SliderEntity> builder)
    {
        builder.ToTable("Slider", "dbo");
        builder.HasQueryFilter(f => f.IsDeleted == false);
    }
}
