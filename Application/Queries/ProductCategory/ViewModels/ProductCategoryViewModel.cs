namespace Application.Queries.ProductCategory.ViewModels;

public sealed record ProductCategoryViewModel
{
    public Guid Id { get; set; }
    public string? ParentTitle { get; set; }
    public string? ImagePath { get; set; }
    public string? Title { get; set; }

}
