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
}
