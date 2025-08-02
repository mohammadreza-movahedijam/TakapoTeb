using Microsoft.EntityFrameworkCore;
using Domain.Entities.System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Mapping;

internal sealed class QuestionMap :
    IEntityTypeConfiguration<QuestionEntity>
{
    public void Configure(EntityTypeBuilder<QuestionEntity> builder)
    {
        builder.ToTable("Question", "dbo");
        builder.HasQueryFilter(f => f.IsDeleted == false);

    }
}
