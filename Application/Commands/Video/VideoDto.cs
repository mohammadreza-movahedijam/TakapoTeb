using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Video;

public sealed record VideoDto
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    [Required(ErrorMessage ="لینک ویدئو را وارد نمائید")]
    public string? Link { set; get; }
}
