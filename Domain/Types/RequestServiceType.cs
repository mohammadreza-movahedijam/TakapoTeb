using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types;

public enum RequestServiceType
{
    [Display(Name ="سرویس فوری")]
    Urgent,
    [Display(Name = "سرویس دوره ای PM")]
    Periodic
}
