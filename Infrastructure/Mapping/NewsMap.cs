using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class NewsMap : IEntityTypeConfiguration<NewsEntity>
{
    public void Configure(EntityTypeBuilder<NewsEntity> builder)
    {
        builder.ToTable("News", "dbo");
        builder.HasQueryFilter(f=>f.IsDeleted==false);
    }
}
