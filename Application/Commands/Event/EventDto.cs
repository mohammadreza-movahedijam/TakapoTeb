using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Event;

public sealed record EventDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage ="عنوان فارسی الزامی است")]
    public string? TitleFa { get; set; }
    [Required(ErrorMessage = "عنوان انگلیسی الزامی است")]
    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
}
