namespace Domain.Entities.System;

public class SettingEntity : BaseEntity
{
    public string? TopLogoPath { get; set; }
    public string? BottomLogoPath { get; set; }
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
    public string? WorkingHoursFa {  get; set; }
    public string? WorkingHoursEn {  get; set; }
    public string? Email {  get; set; }
    public string? Latitude { set; get; }
    public string? Longitude { set; get; }
    public string? AboutFa { get; set; }
    public string? AboutEn { get; set; }
    public string? AboutImagePath { get; set; }
    public int YearsExperience { get; set; }

}
