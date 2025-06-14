using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class ChatGroupMap :
    IEntityTypeConfiguration<ChatGroupEntity>
{
    public void Configure(EntityTypeBuilder<ChatGroupEntity> builder)
    {
        builder.ToTable("ChatGroup");
        builder.HasMany(m => m.chatMessages)
            .WithOne(o => o.ChatGroup)
            .HasForeignKey(f => f.ChatGroupId);
    }
}
