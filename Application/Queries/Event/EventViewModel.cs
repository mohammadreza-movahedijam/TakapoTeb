using System.ComponentModel.DataAnnotations;

namespace Application.Queries.Event;

public sealed record EventViewModel
{
    public Guid Id { get; set; }
    public string? TitleFa { get; set; }
}