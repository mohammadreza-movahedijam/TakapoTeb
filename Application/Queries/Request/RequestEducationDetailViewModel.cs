using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Request;

public sealed record RequestEducationDetailViewModel
{
    public string? TreatmentCenterName { set; get; }
    public string? FullName { set; get; }
    public string? Mobile { get; set; }
    public string? DeviceSerialNumber { get; set; }
    public string? DeviceName { get; set; }
    public string? EducationType { get; set; }
    public string? Description { get; set; }
    public string? CreatedAt { get; set; }
    public List<string>? Files { get; set; }
}
