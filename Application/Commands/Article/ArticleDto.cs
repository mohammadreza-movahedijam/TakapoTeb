using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Article;

public sealed record ArticleDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage ="عنوان فارسی الزامی است")]
    public string? TitleFa { get; set; }
    [Required(ErrorMessage = "عنوان انگلیسی الزامی است")]
    public string? TitleEn { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? ImageFile { get; set; }
    [Required(ErrorMessage = "متن فارسی الزامی است")]
    public string? TextFa { get; set; }
    [Required(ErrorMessage = "متن انگلیسی الزامی است")]
    public string? TextEn { get; set; }
    [Required(ErrorMessage = "انتخاب دسته بندی الزامی است")]
    public Guid CategoryId { get; set; }

    [Required(ErrorMessage = "خلاصه انگلیسی الزامی است")]
    public string? SummaryEn { get; set; }
    [Required(ErrorMessage = "خلاصه فارسی الزامی است")]

    public string? SummaryFa { get; set; }
}
