using Microsoft.AspNetCore.Http;

namespace Application.Commands.Product;

public sealed record ProductDto
{
    public Guid? Id { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? TitleFa { get; set; }
    public string? DescrptionFa { get; set; }
    public string? TitleEn { get; set; }
    public string? DescrptionEn { get; set; }
    public string? VideoLink { get; set; }
    public string? CategoryTitleFa { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? OldCategoryId { get; set; }
    public List<Guid>? RelatedProducts { get; set; }
}
