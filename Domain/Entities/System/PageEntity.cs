using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System;

public class PageEntity:BaseEntity,IDelete
{
    public string? ImagePath { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionFa { get; set; }
    public bool IsShowOnMenu {  get; set; }
    public bool IsActivePage { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
    #region Relation 
    public PageEntity? ParentPage { get; set; }
    public Guid? ParentPageId { get; set; }
    public ICollection<PageEntity>? SubPages { get; }
    #endregion
    public bool IsDeleted { get; set; } = false;
}
