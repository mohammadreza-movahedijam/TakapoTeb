using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Statistic;

public sealed record StatisticDto
{
    public int NumberOne { get; set; }
    public string? TitleFaOne { get; set; }
    public string? TitleEnOne { get; set; }
    public int NumberTwo { get; set; }
    public string? TitleFaTwo { get; set; }
    public string? TitleEnTwo { get; set; }
    public int NumberThree { get; set; }
    public string? TitleFaThree { get; set; }
    public string? TitleEnThree { get; set; }
    public int NumberFour { get; set; }
    public string? TitleFaFour { get; set; }
    public string? TitleEnFour { get; set; }
}
