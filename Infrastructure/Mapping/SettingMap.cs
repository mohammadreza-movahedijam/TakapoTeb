using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class SettingMap : IEntityTypeConfiguration<SettingEntity>
{
    public void Configure(EntityTypeBuilder<SettingEntity> builder)
    {
        builder.ToTable("Setting");
        builder.HasData(new SettingEntity()
        {
            Id= Guid.Parse("b6a6e1eb-8ef7-45ea-aef9-f199b96f92a9"),
            TopLogoPath=string.Empty,
            BottomLogoPath = string.Empty,
            Linkedin = string.Empty,
            Instagram = string.Empty,
            WhatsApp = string.Empty,
            Telegram = string.Empty,
            LocationFa = string.Empty,
            LocationEn = string.Empty,
            ContactNumber = string.Empty,
            Video = string.Empty,
            DescriptionEn = string.Empty,
            DescriptionFa = string.Empty,
            AboutEn = string.Empty,
            AboutFa = string.Empty,
            AboutImagePath = string.Empty,
            YearsExperience = 0,
            WorkingHoursEn=string.Empty,
            WorkingHoursFa=string.Empty,

        });
    }
}
