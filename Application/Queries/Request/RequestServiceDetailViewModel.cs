using Domain.Types;

namespace Application.Queries.Request;

public sealed record RequestServiceDetailViewModel
{
    public string? TreatmentCenterName { set; get; }
    public string? FullName { set; get; }
    public string? Mobile { get; set; }
    public string? DeviceSerialNumber { get; set; }
    public string? DeviceName { get; set; }
    public string? RequestType { get; set; }
    public string? Description { get; set; }
    public string? CreatedAt { get; set; } 
    public List<string>? Files { get; set; }
}
