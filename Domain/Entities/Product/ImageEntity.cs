namespace Domain.Entities.Product;

public class ImageEntity : BaseEntity, IDelete
{

    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? Path { get; set; }
    #region Relation 
    public Guid ProductId { set; get; }
    public ProductEntity? Product { set; get; }
    #endregion
    public bool IsDeleted { get; set; } = false;
}
