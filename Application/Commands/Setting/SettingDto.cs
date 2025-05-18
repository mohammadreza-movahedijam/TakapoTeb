using Microsoft.AspNetCore.Http;

namespace Application.Commands.Setting;

public sealed record SettingDto
{

    public IFormFile? TopLogoFile { get; set; }
    public IFormFile? BottomLogoFile { get; set; }
    public string? TopLogoPath { get; set; }
    public string? BottomLogoPath { get; set; }

    public string? Linkedin { get; set; }
    public string? Instagram { get; set; }
    public string? WhatsApp { get; set; }
    public string? Telegram { get; set; }

    public string? Location { get; set; }
    public string? ContactNumber { get; set; }
    public string? Video { get; set; }


    public string? Description { get; set; }
    public string? About { get; set; }
    public string? AboutImagePath { get; set; }    public IFormFile? AboutImageFile { get; set; }
    public int YearsExperience { get; set; }
}
