namespace Application.Queries.ProductCategory.ViewModels;

public sealed record CategoryDetailViewModel
{
    public Guid Id { get; set; }
    public string? ImagePath { get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionFa { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ColorFrom { get; set; }
    public string? ColorTo { get; set; }

}
