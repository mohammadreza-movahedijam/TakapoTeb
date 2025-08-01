using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Page;

public sealed record PageViewModel
{
    public Guid Id { get; set; }
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    public bool IsShowOnMenu { get; set; }
}
