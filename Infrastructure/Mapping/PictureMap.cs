using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class PictureMap : IEntityTypeConfiguration<PictureEntity>
{
    public void Configure(EntityTypeBuilder<PictureEntity> builder)
    {
        builder.HasQueryFilter(f => f.IsDeleted == false);

        builder.ToTable("Picture", "dbo");
    }
}
