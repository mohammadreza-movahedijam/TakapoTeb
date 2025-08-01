using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Page;

public sealed record PageDetailViewModel
{
    public string? ImagePath { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionFa { get; set; }
}
