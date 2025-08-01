namespace Domain.Entities.System;

public class VideoEntity : BaseEntity, IDelete
{
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    public string? Link { set; get; }
    #region Relation
    public EventEntity? Event {  get; set; }
    public Guid? EventId {  get; set; }
    #endregion
    public bool IsDeleted { get; set; } = false;
}
