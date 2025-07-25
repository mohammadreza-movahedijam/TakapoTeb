namespace Application.Queries.Partner;

public sealed record PartnerDetailViewModel
{
    public Guid Id { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionFa { get; set; }
    public string? LogoPath { get; set; }
    public string? Link { get; set; }
}
