using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.NewsCategory;

public sealed record NewsCategoryViewModel
{
    public Guid Id { get; set; }
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
}
