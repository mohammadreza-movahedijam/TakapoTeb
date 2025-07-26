

namespace Domain.Entities.System;


public class RequestServiceAttachEntity :BaseEntity
{
  public string? FilePath { get; set; }
    #region Relation
    public Guid RequestServiceId { get; set; }
    public RequestServiceEntity? RequestService { get; set; }
    #endregion

}
