using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class StatisticMap :
    IEntityTypeConfiguration<StatisticEntity>
{
    public void Configure(EntityTypeBuilder<StatisticEntity> builder)
    {
        builder.ToTable("Statistic");
        builder.HasData(new StatisticEntity()
        {
            Id = Guid.Parse("6b067bbc-a472-4683-b1f1-bf44b3aa51f1"),
            NumberOne = 0,
            TitleFaOne = "",
            TitleEnOne = "",
            NumberTwo = 0,
            TitleFaTwo = "",
            TitleEnTwo = "",
            NumberThree = 0,
            TitleFaThree = "",
            TitleEnThree = "",
            NumberFour = 0,
            TitleFaFour = "",
            TitleEnFour = ""

        });
    }
}
