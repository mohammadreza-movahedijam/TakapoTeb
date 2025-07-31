using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class RequestEducationAttachMap :
    IEntityTypeConfiguration<RequestEducationAttachEntity>
{
    public void Configure(EntityTypeBuilder<RequestEducationAttachEntity> builder)
    {
        builder.ToTable("RequestEducationAttach", "dbo");
    }
}
