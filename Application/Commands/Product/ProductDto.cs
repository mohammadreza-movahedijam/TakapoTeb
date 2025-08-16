using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Product;

public sealed record ProductDto:IValidatableObject
{
    public Guid? Id { get; set; }
    public string? ImageHeaderPath { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? ImageFile { get; set; }
    public IFormFile? ImageHeaderFile { get; set; }
    [Required(ErrorMessage ="عنوان فارسی الزامی است")]
    public string? TitleFa { get; set; }
    [Required(ErrorMessage = "توضیح فارسی الزامی است")]
    public string? DescrptionFa { get; set; }
    [Required(ErrorMessage = "عنوان انگلیسی الزامی است")]
    public string? TitleEn { get; set; }
    [Required(ErrorMessage = "توضیح انگلیسی الزامی است")]
    public string? DescrptionEn { get; set; }
    public string? VideoLink { get; set; }
    public string? CategoryTitleFa { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? OldCategoryId { get; set; }
    public List<Guid>? RelatedProducts { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (string.IsNullOrEmpty(ImagePath) && ImageFile is null)
        {
            results.Add(new ValidationResult("تصویر را آپلود نمائید", new[] { nameof(ImageFile) }));

        }
        return results;
    }
}
