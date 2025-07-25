namespace Domain.Entities.Product;

public class TreatmentCenterEntity:BaseEntity,IDelete
{
    public string? Image {  get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionFa { get; set; }

    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
    public string? PhoneNumber { get; set; }


    public string? Latitude { set; get; }
    public string? Longitude { set; get; }
    #region Relation
    public ProductEntity? Product { get; set; }
    public Guid ProductId { get; set; }
    #endregion
    public bool IsDeleted { get; set; }
}
