using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Setting.ViewModels;

public sealed record AcademyViewModel
{
    public string? AcademyTitleEn { get; set; }
    public string? AcademyTitleFa { get; set; }
    public string? AcademyTextFa { get; set; }
    public string? AcademyTextEn { get; set; }
    public string? AcademyImagePath { get; set; }
}
