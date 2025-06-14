using Domain.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.System;

[Table("ChatMessage")]
public class ChatMessageEntity : BaseEntity
{
    public string? IPAddress { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public string? Message { get; set; }
    public UserType UserType { get; set; }
    #region Relation
    public Guid ChatGroupId { get; set; }
    public ChatGroupEntity? ChatGroup { get; set; }
    #endregion
}
