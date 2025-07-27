using Domain.Types;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.RequestEducation;
public sealed record RequestEducationDto
{
    public string? TreatmentCenterName { set; get; }
    public string? FullName { set; get; }
    public string? Mobile { get; set; }
    public string? DeviceSerialNumber { get; set; }
    public string? DeviceName { get; set; }
    public RequestEducationType EducationType { get; set; }
    public string? Description { get; set; }
    public List<IFormFile>? Attachments { get; set; }
}
