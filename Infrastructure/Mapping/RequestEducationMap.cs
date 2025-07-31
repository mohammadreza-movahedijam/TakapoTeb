using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class RequestEducationMap :
    IEntityTypeConfiguration<RequestEducationEntity>
{
    public void Configure(EntityTypeBuilder<RequestEducationEntity> builder)
    {
        builder.ToTable("RequestEducation", "dbo");
        builder.HasMany(m => m.RequestEducationAttaches)
            .WithOne(o => o.RequestEducation)
            .HasForeignKey(f => f.RequestEducationId);
    }

}
