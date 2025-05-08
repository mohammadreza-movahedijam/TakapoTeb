using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ProductCategory;

public sealed record ProductCategoryDto
{
    public Guid Id { get; set; }
    public Guid? ParentProductCategoryId { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? ImageFile { get; set; }
    [Required(ErrorMessage ="عنوان فارسی الزامی است")]
    public string? TitleFa { get; set; }
    public string? DescriptionFa { get; set; }
    [Required(ErrorMessage = "عنوان انگلیسی الزامی است")]
    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
}
