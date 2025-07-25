using Domain.Types;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.News;

public sealed record NewsDto: IValidatableObject
{
    public Guid Id { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? ImagePath { get; set; }


    [Required(ErrorMessage = "عنوان انگلیسی الزامی است")]
    public string? TitleEn { get; set; }
    [Required(ErrorMessage = "عنوان فارسی الزامی است")]
    public string? TitleFa { get; set; }
    public TopicType TopicType { get; set; }
    [Required(ErrorMessage = "متن فارسی الزامی است")]
    public string? DescriptionEn { get; set; }
    [Required(ErrorMessage = "متن انگلیسی الزامی است")]
    public string? DescriptionFa { get; set; }
    public string? ReferencesLink { set; get; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (string.IsNullOrEmpty(ImagePath) && ImageFile is null)
        {
            results.Add(new ValidationResult(" تصویر را آپلود نمائید", new[] { nameof(ImageFile) }));

        }
        return results;
    }
}
