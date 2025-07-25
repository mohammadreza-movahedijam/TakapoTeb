using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Feedback;

public sealed record FeedbackDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "نام فارسی الزامی است")]
    public string? FullNameFa { get; set; }
    [Required(ErrorMessage = "موقعیت شغلی فارسی الزامی است")]
    public string? JobPositionFa { get; set; }
    [Required(ErrorMessage = "توضیح فارسی الزامی است")]
    public string? ExplanationFa { get; set; }

    [Required(ErrorMessage = "نام انگلیسی الزامی است")]
    public string? FullNameEn { get; set; }
    [Required(ErrorMessage = "موقعیت شغلی انگلیسی الزامی است")]
    public string? JobPositionEn { get; set; }
    [Required(ErrorMessage = "توضیح انگلیسی الزامی است")]
    public string? ExplanationEn { get; set; }
}
