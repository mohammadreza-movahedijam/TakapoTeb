namespace Domain.Entities.Product;

public class ProductEntity : BaseEntity,IDelete
{
    public string? ImagePath { get; set; }
    public string? TitleFa { get; set; }
    public string? DescrptionFa { get; set; }
    public string? TitleEn { get; set; }
    public string? DescrptionEn { get; set; }
    public string? VideoLink { get; set; }
    #region Relation
    public virtual ICollection<ProductOptionEntity>? ProductOptions { get; set; }
    public CategoryEntity? Category { get; set; }
    public Guid? CategoryId { get; set; }
    #endregion
    public bool IsDeleted { get ; set ; }=false;
}
