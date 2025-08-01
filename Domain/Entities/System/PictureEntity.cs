namespace Domain.Entities.System;

public class PictureEntity : BaseEntity, IDelete
{
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    public string? FilePath { set; get; }
    #region Relation
    public EventEntity? Event { get; set; }
    public Guid? EventId { get; set; }
    #endregion
    public bool IsDeleted { get; set; } = false;
}
