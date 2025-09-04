namespace Application.Queries.Product.ViewModels;
public sealed record ProductDetailViewModel
{
    public Guid Id { get; set; }
    public string? ImagePath { get; set; }
    public string? ImageHeaderPath { get; set; }
    public string? TitleFa { get; set; }
    public string? DescrptionFa { get; set; }
    public string? TitleEn { get; set; }
    public string? DescrptionEn { get; set; }
    public string? VideoLink { get; set; }
    public string? DescrptionSectionTwoFa { get; set; }
    public string? DescrptionSectionTwoEn { get; set; }
    public string? SummaryFa { get; set; }
    public string? SummaryEn { get; set; }
    public string? ColorFrom { get; set; }
    public string? ColorTo { get; set; }
    public string? ButtonFa { get; set; }
    public string? ButtonEn { get; set; }
    public string? ButtonLink { get; set; }
}
