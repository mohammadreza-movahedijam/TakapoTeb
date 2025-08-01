using Microsoft.AspNetCore.Http;

namespace Application.Commands.Setting;

public sealed record SettingDto
{
    public IFormFile? AboutPageImageFile { get; set; }
    public string? AboutImage { get; set; }
    public string? AboutTitleEn { get; set; }
    public string? AboutTitleFa { get; set; }
    public string? AboutDescriptionEn { get; set; }
    public string? AboutDescriptionFa { get; set; }

    public IFormFile? TopLogoFileEn { get; set; }
    public IFormFile? BottomLogoFileEn { get; set; }
    public string? TopLogoPathEn { get; set; }
    public string? BottomLogoPathEn { get; set; }

    public IFormFile? TopLogoFileFa { get; set; }
    public IFormFile? BottomLogoFileFa { get; set; }
    public string? TopLogoPathFa { get; set; }
    public string? BottomLogoPathFa { get; set; }



    public string? WorkingHoursFa { get; set; }
    public string? WorkingHoursEn { get; set; }
    public string? Linkedin { get; set; }
    public string? Instagram { get; set; }
    public string? WhatsApp { get; set; }
    public string? Telegram { get; set; }

    public string? LocationEn { get; set; }
    public string? LocationFa { get; set; }
    public string? ContactNumber { get; set; }
    public string? Video { get; set; }


    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
    public string? AboutFa { get; set; }
    public string? AboutEn { get; set; }
    public string? AboutImagePath { get; set; } 
    public IFormFile? AboutImageFile { get; set; }
    public int YearsExperience { get; set; }

    public string? Email { get; set; }
    public string? Latitude { set; get; }
    public string? Longitude { set; get; }



    #region ColumnOne

    public string? ColumnOneTitleFa { get; set; }
    public string? ColumnOneTitleEn { get; set; }


    public string? ColumnOneItemOneTitleEn { get; set; }
    public string? ColumnOneItemOneTitleFa { get; set; }
    public string? ColumnOneItemOneLink { get; set; }

    public string? ColumnOneItemTwoTitleEn { get; set; }
    public string? ColumnOneItemTwoTitleFa { get; set; }
    public string? ColumnOneItemTwoLink { get; set; }


    public string? ColumnOneItemThreeTitleEn { get; set; }
    public string? ColumnOneItemThreeTitleFa { get; set; }
    public string? ColumnOneItemThreeLink { get; set; }


    public string? ColumnOneItemFourTitleEn { get; set; }
    public string? ColumnOneItemFourTitleFa { get; set; }
    public string? ColumnOneItemFourLink { get; set; }


    #endregion

    #region ColumnTwo

    public string? ColumnTwoTitleFa { get; set; }
    public string? ColumnTwoTitleEn { get; set; }


    public string? ColumnTwoItemOneTitleEn { get; set; }
    public string? ColumnTwoItemOneTitleFa { get; set; }
    public string? ColumnTwoItemOneLink { get; set; }


    public string? ColumnTwoItemTwoTitleEn { get; set; }
    public string? ColumnTwoItemTwoTitleFa { get; set; }
    public string? ColumnTwoItemTwoLink { get; set; }


    public string? ColumnTwoItemThreeTitleEn { get; set; }
    public string? ColumnTwoItemThreeTitleFa { get; set; }
    public string? ColumnTwoItemThreeLink { get; set; }


    public string? ColumnTwoItemFourTitleEn { get; set; }
    public string? ColumnTwoItemFourTitleFa { get; set; }
    public string? ColumnTwoItemFourLink { get; set; }
    #endregion
}
