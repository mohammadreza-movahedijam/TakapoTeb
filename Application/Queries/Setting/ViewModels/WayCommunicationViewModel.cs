using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Setting.ViewModels;

public sealed record WayCommunicationViewModel
{
    public string? Linkedin { get; set; }
    public string? Instagram { get; set; }
    public string? WhatsApp { get; set; }
    public string? Telegram { get; set; }
    public string? LocationEn { get; set; }
    public string? LocationFa { get; set; }
    public string? ContactNumber { get; set; }
    public string? WorkingHoursFa { get; set; }
    public string? WorkingHoursEn { get; set; }
}
