using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Video;

public sealed record VideoViewModel
{
    public Guid Id { get; set; }
    public string? TitleFa { get; set; }
    public string? Link { set; get; }
}
