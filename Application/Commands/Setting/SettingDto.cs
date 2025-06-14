using Microsoft.AspNetCore.Http;

namespace Application.Commands.Setting;

public sealed record SettingDto
{

    public IFormFile? TopLogoFile { get; set; }
    public IFormFile? BottomLogoFile { get; set; }
    public string? TopLogoPath { get; set; }
    public string? BottomLogoPath { get; set; }
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
}
