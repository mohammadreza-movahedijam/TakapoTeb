using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Partner;

public sealed record PartnerDto:IValidatableObject
{
    public Guid Id { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionFa { get; set; }
    public IFormFile? File { get; set; }
    public string? LogoPath { get; set; }
    public string? Link { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (string.IsNullOrEmpty(LogoPath) && File is null)
        {
            results.Add(new ValidationResult("لوگو را آپلود نمائید", new[] { nameof(File) }));

        }
        return results;
    }
}
