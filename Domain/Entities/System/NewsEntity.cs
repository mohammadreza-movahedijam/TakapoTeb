using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System;

public class NewsEntity : BaseEntity,IDelete
{
    public string? ImagePath { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionFa { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public string? ReferencesLink {set;get;}
    public TopicType TopicType { get; set; }
    public bool IsDeleted { get; set ; }=false;
}
