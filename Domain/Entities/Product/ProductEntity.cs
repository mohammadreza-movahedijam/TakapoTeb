namespace Domain.Entities.Product;

public class ProductEntity : BaseEntity,IDelete
{
    public string? DescrptionSectionTwoFa { get; set; }
    public string? DescrptionSectionTwoEn { get; set; }
    public string? SummaryFa { get; set; }
    public string? SummaryEn { get; set; }
    public string? ColorFrom { get; set; }
    public string? ColorTo { get; set; }
    public string? ButtonFa { get; set; }
    public string? ButtonEn { get; set; }
    public string? ButtonLink { get; set; }
    public string? ImageHeaderPath { get; set; }
    public string? ImagePath { get; set; }
    public string? TitleFa { get; set; }
    public string? DescrptionFa { get; set; }
    public string? DescrptionEn { get; set; }
    public string? TitleEn { get; set; }
  
    public string? VideoLink { get; set; }
    public DateTime? DateCreated { get; set; }
    #region Relation
    public virtual ICollection<ImageEntity>? Images {  get; set; }
    public virtual ICollection<DocumentEntity>? Documents {  get; set; }
    public virtual ICollection<OptionEntity>? Options { get; set; }
    public virtual ICollection<RelatedEntity>? Relateds { get; set; }
    public virtual ICollection<TreatmentCenterEntity>? TreatmentCenters { get; set; }
    public CategoryEntity? Category { get; set; }
    public Guid? CategoryId { get; set; }
    #endregion
    public bool IsDeleted { get ; set ; }=false;
}
