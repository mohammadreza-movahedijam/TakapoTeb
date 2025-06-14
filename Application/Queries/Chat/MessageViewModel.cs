namespace Application.Queries.Chat;

public sealed record MessageViewModel
{
    public string? CreateAt { get; set; }
    public string? Message { get; set; }
    public string? UserType { get; set; }
}
