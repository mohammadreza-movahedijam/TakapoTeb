namespace Domain.Entities.Product;

public class CategoryEntity : BaseEntity,IDelete
{
    public string? ImagePath { get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionFa { get; set; }

    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ColorFrom { get; set; }
    public string? ColorTo { get; set; }
    public int DisplayPriority {  get; set; }

    #region Relation 
    public CategoryEntity? ParentCategory { get; set; }
    public Guid? ParentProductCategoryId { get; set; }
    public ICollection<ProductEntity>?Products { get; set; } 
    public ICollection<CategoryEntity>? SubCategories { get; } 
    #endregion

    public bool IsDeleted { get; set; }


}
