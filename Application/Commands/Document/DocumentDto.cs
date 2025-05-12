using Microsoft.AspNetCore.Http;

namespace Application.Commands.Document;

public sealed record DocumentDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; } 
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    public string? FilePath { get; set; }
    public IFormFile? File { get; set; }
}
