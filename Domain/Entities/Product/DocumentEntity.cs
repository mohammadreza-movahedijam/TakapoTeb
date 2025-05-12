namespace Domain.Entities.Product;

public class DocumentEntity : BaseEntity, IDelete
{
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    public string? FilePath { get; set; }
    #region Relation
    public ProductEntity? Product { get; set; }
    public Guid ProductId { get; set; }
    #endregion
    public bool IsDeleted { get; set; }
}
