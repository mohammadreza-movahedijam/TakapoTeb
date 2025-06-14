using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System;

public class ChatGroupEntity:BaseEntity
{
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public string? ConnectionId { get; set; }
    public string? IPAddress { get; set; }

    #region Relation
    public ICollection<ChatMessageEntity>? chatMessages { get; set; }
    #endregion
}
