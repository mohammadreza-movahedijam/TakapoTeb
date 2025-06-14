namespace Application.Queries.Product.ViewModels;
public sealed record RelatedProductViewModel
{
    public Guid? Id { get; set; }
    public string? Title { get; set; }
    public string? TitleEn { get; set; }
}
