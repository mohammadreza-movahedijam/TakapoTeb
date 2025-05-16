using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Blog;

public class CategoryEntity:BaseEntity,IDelete
{
    public string? TitleFa {  get; set; }
    public string? TitleEn {  get; set; }
    #region Relation
    public virtual ICollection<ArticleEntity>? Articles { get; set; }
    #endregion
    public bool IsDeleted { get ; set ; }=false;
}
