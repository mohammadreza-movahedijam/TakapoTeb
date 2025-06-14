using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Setting.ViewModels;

public sealed record AboutSectionViewModel
{
    public string? AboutEn { get; set; }
    public string? AboutFa { get; set; }
    public string? AboutImagePath { get; set; }
    public int YearsExperience { get; set; }
}
