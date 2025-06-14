using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Image;

public sealed record ImageDto
{
    public Guid ProductId { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    [Required(ErrorMessage ="فایل را وارد کنید")]
    public IFormFile? File { get; set; }
}
