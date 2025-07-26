using Domain.Types;

namespace Domain.Entities.System;

public class RequestServiceEntity : BaseEntity
{
    public string? TreatmentCenterName { set; get; }
    public string? FullName { set; get; }
    public string? Mobile { get; set; }
    public string? DeviceSerialNumber { get; set; }
    public string? DeviceName { get; set; }
    public RequestServiceType RequestType { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public bool IsSeen { get; set; } = false;

    #region Relation
    public virtual ICollection<RequestServiceAttachEntity>? RequestServiceAttaches { get; set; }
    #endregion

}
