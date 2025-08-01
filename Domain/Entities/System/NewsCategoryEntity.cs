namespace Domain.Entities.System;

public class NewsCategoryEntity : BaseEntity, IDelete
{
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    public DateTime? CreatedDate { get; set; }=DateTime.Now;
    #region Relation
    public virtual ICollection<NewsEntity>? News { get; set; }
    #endregion
    public bool IsDeleted { get; set; } = false;
}
