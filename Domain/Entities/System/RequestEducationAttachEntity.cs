using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System;

public class RequestEducationAttachEntity:BaseEntity
{
    public string? FilePath { get; set; }
    #region Relation
    public Guid RequestEducationId { get; set; }
    public RequestEducationEntity? RequestEducation { get; set; }
    #endregion

}
