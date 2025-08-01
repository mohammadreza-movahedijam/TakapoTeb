﻿using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class PageMap :
    IEntityTypeConfiguration<PageEntity>
{
    public void Configure(EntityTypeBuilder<PageEntity> builder)
    {
        builder.ToTable("Page","dbo");
        builder.HasQueryFilter(f => f.IsDeleted == false);
    }
}
