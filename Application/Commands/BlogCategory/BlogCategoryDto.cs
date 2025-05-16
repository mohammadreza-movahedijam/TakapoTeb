using System.ComponentModel.DataAnnotations;

namespace Application.Commands.BlogCategory;

public sealed record BlogCategoryDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage ="عنوان فارسی الزامی است")]
    public string? TitleFa { get; set; }
    [Required(ErrorMessage = "عنوان انگلیسی الزامی است")]
    public string? TitleEn { get; set; }
}
