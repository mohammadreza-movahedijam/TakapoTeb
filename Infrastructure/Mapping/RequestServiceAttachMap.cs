using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class RequestServiceAttachMap :
    IEntityTypeConfiguration<RequestServiceAttachEntity>
{
    public void Configure(EntityTypeBuilder<RequestServiceAttachEntity>
        builder)
    {
        builder.ToTable("RequestServiceAttach", "dbo");
    }
}
