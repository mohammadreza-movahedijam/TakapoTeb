namespace Domain.Entities.Product;

public class RelatedEntity : BaseEntity
{
    public Guid RelatedId { get; set; }
    #region Relation
    public Guid ProductId { get; set; }
    public ProductEntity? Product { get; set; }
    #endregion
}
