namespace Application.Queries.Image;

public sealed record ImageViewModel
{
    public Guid Id { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? Path { get; set; }
}
