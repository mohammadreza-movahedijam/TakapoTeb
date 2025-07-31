namespace Application.Queries.Catalog;

public sealed record CatalogDetailViewModel
{
    public string? FilePath { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }

    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
}
