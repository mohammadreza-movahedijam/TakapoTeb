using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Option;

public sealed record OptionDto:IValidatableObject
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "عنوان فارسی الزامی است")]
    public string? TitleFa { set; get; }
    public string? DescriptionFa { set; get; }
    [Required(ErrorMessage = "عنوان انگلیسی الزامی است")]
    public string? TitleEn { set; get; }
    public string? DescriptionEn { set; get; }
    public string? ImagePath { set; get; }
    public IFormFile? ImageFile { set; get; }   
    public Guid ProductId { set; get; }
    public string? ProductTitleFa { set; get;}

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
