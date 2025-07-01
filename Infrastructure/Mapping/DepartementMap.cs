using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class DepartementMap :
    IEntityTypeConfiguration<DepartementEntity>
{
    public void Configure(EntityTypeBuilder<DepartementEntity> builder)
    {
        builder.ToTable("Departement");
        builder.HasQueryFilter(f => f.IsDeleted == false);
    }
}
