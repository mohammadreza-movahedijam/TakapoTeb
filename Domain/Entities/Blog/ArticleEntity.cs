namespace Domain.Entities.Blog;

public class ArticleEntity : BaseEntity, IDelete
{
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    public string? ImagePath { get; set; }
    public string? TextFa { get; set; }
    public string? TextEn { get; set; }
    #region Relation
    public Guid CategoryId { get; set; }
    public Domain.Entities.Blog.CategoryEntity? Category { get; set; }
    #endregion
    public bool IsDeleted { get; set; } = false;
}
