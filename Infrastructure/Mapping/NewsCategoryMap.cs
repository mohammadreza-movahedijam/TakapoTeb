using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class NewsCategoryMap :
    IEntityTypeConfiguration<NewsCategoryEntity>
{
    public void Configure(EntityTypeBuilder<NewsCategoryEntity> builder)
    {
        builder.HasQueryFilter(f => f.IsDeleted == false);

        builder.ToTable("NewsCategory","dbo");
        builder.HasMany(m => m.News)
            .WithOne(o => o.NewsCategory)
            .HasForeignKey(f => f.NewsCategoryId);
    }
}
