using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Setting.ViewModels;

public sealed record AboutViewModel
{
    public string? AboutImage { get; set; }
    public string? AboutTitleEn { get; set; }
    public string? AboutTitleFa { get; set; }
    public string? AboutDescriptionEn { get; set; }
    public string? AboutDescriptionFa { get; set; }
}
