using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System;

public class EventEntity : BaseEntity, IDelete
{
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
    #region Relation
    public ICollection<VideoEntity>? Videos { get; set; }
    public ICollection<PictureEntity>? Pictures { get; set; }
    #endregion
    public bool IsDeleted { get; set; } = false;
}
