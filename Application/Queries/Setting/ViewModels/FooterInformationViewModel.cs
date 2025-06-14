namespace Application.Queries.Setting.ViewModels;

public sealed record FooterInformationViewModel
{
    public string? BottomLogoPath { get; set; }
    public string? Linkedin { get; set; }
    public string? Instagram { get; set; }
    public string? WhatsApp { get; set; }
    public string? Telegram { get; set; }
    public string? DescriptionFa { get; set; }
    public string? DescriptionEn { get; set; }
}
