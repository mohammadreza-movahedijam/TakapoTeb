using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Document;

public sealed record DocumentDto : IValidatableObject
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    [Required(ErrorMessage = "نام فارسی الزامی است")]
    public string? TitleFa { get; set; }
    [Required(ErrorMessage = "نام انگلیسی الزامی است")]
    public string? TitleEn { get; set; }
    public string? FilePath { get; set; }
    public IFormFile? File { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();
        if (string.IsNullOrEmpty(FilePath) && File is null)
        {
            results.Add(new ValidationResult("فایل را آپلود نمائید", new[] { nameof(File) }));

        }
        return results;
    }
}
