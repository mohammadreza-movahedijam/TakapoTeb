using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Request;

public sealed record RequestViewModel
{
    public Guid Id { get; set; }
    public string? TreatmentCenterName { set; get; }
    public string? FullName { set; get; }
    public string? DeviceName { get; set; }
    public string? CreatedAt { get; set; }
}
