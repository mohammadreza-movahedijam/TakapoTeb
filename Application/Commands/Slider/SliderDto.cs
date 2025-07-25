using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Slider;

public sealed record SliderDto:IValidatableObject
{
    public Guid? Id { get; set; }
    public IFormFile? File { get; set; }
    public string? ImagePath { get; set; }
    public string? Title { get; set; }
    public string? Alt { get; set; }
    public string? Link { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (string.IsNullOrEmpty(ImagePath) && File is null)
        {
            results.Add(new ValidationResult("تصویر را آپلود نمائید", new[] { nameof(File) }));

        }
        return results;
    }
}
