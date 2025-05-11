using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product;

public class ProductOptionEntity:BaseEntity,IDelete
{
    public string? TitleFa { set; get; }
    public string? DescriptionFa { set; get; }   
    public string? TitleEn { set; get; }
    public string? DescriptionEn { set; get; }
    public string? ImagePath { set; get; }
    #region Relation 
    public Guid ProductId { set; get; }
    public ProductEntity? Product { set; get; }
    #endregion
    public bool IsDeleted { get; set; }=false;
}
