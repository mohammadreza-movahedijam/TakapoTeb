namespace Domain.Entities.Product;

public class ProductCategoryEntity : BaseEntity,IDelete
{
    public string? ImagePath { get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionFa { get; set; }

    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }

    #region Relation 
    public ProductCategoryEntity? ParentProductCategory { get; set; }
    public Guid? ParentProductCategoryId { get; set; }

    public ICollection<ProductCategoryEntity>? SubProductCategories { get; } 
    #endregion

    public bool IsDeleted { get; set; }


}
