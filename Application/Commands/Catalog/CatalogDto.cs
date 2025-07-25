using Domain.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Catalog;

public sealed record CatalogDto : IValidatableObject
{
    public Guid Id { get; set; }
    public string? FilePath { get; set; }

    public IFormFile? File { get; set; }
    [Required(ErrorMessage = "عنوان فارسی الزامی است")]

    public string? TitleEn { get; set; }
    [Required(ErrorMessage = "عنوان انگلیسی الزامی است")]

    public string? TitleFa { get; set; }

    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
    [Required(ErrorMessage = "نوع فایل الزامی است")]

    public FileType Type { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();
     
        if (string.IsNullOrEmpty(FilePath) && File is null)
        {
            results.Add(new ValidationResult("فایل را آپلود نمائید", new[] {  nameof(File) }));

        }
        return results;
    }
}
