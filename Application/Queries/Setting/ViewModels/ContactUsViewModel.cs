using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Setting.ViewModels;

public sealed record ContactUsViewModel
{
    public string? ContactNumber { get; set; }

    public string? Email { get; set; }
    public string? Latitude { set; get; }
    public string? Longitude { set; get; }
    public string? LocationEn { get; set; }
    public string? LocationFa { get; set; }
}
