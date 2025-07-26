using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System;

public class RequestEducationEntity:BaseEntity
{
    public string? TreatmentCenterName { set; get; }
    public string? FullName { set; get; }
    public string? Mobile { get; set; }
    public string? DeviceSerialNumber { get; set; }
    public string? DeviceName { get; set; }
    public RequestEducationType EducationType { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public bool IsSeen { get; set; } = false;
    #region Relation
    public virtual ICollection<RequestEducationAttachEntity>? RequestEducationAttaches { get; set; }
    #endregion

}
