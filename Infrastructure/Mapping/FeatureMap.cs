using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class FeatureMap :
    IEntityTypeConfiguration<FeatureEntity>
{
    public void Configure(EntityTypeBuilder<FeatureEntity> builder)
    {
        builder.ToTable("Feature", "dbo");
        builder.HasData(new FeatureEntity()
        {
            Id = Guid.Parse("b6a6e1eb-8ef7-45ea-aef9-f199b96f92a9"),
            ImageOne = "",
            ImageTwo = "",
            ImageThree = "",
            ImageFour = "",
            TitleEnOne
            = "",
            TitleEnTwo
            = "",
            TitleEnThree
            = "",
            TitleEnFour
            = "",
            TitleFaOne
            = "",
            TitleFaTwo
            = "",
            TitleFaThree
            = "",
            TitleFaFour
            = "",
            TextEnOne
            = "",
            TextEnTwo
            = "",
            TextEnThree
            = "",
            TextEnFour
            = "",
            TextFaOne
            = "",
            TextFaTwo
            = "",
            TextFaThree
            = "",
            TextFaFour = "",
            LinkOne="#",
            LinkTwo="#",
            LinkThree="#",
            LinkFour="#"
        });
    }
}
