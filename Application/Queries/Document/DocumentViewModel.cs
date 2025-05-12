namespace Application.Queries.Document;

public sealed record DocumentViewModel
{
    public Guid Id { get; set; }
    public string? TitleFa { get; set; }
    public string? FilePath { get; set; }
}
