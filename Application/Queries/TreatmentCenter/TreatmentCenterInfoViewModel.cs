namespace Application.Queries.TreatmentCenter;

public sealed record TreatmentCenterInfoViewModel
{
    public Guid Id { get; set; }
    public string? Image { get; set; }

    public string? TitleFa { get; set; }
    public string? DescriptionFa { get; set; }

    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
    public string? PhoneNumber { get; set; }

    public string? ProductTitleEn { get; set; }
    public string? ProductTitleFa { get; set; }
}
