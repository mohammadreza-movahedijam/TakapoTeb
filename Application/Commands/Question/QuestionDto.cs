using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Question;

public sealed record QuestionDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage ="عنوان سوال را وارد کنید")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "گزینه اول الزامی است")]
    public string? OptionOne { get; set; }
    [Required(ErrorMessage = "گزینه دوم الزامی است")]
    public string? OptionTwo { get; set; }
    [Required(ErrorMessage = "گزینه سوم الزامی است")]
    public string? OptionThree { get; set; }
    [Required(ErrorMessage = "گزینه چهارم الزامی است")]
    public string? OptionFour { get; set; }
}
