using Microsoft.AspNetCore.Http;

namespace Application.Commands.Partner;

public sealed record PartnerDto
{
    public Guid Id { get; set; }
    public IFormFile? File { get; set; }
    public string? LogoPath { get; set; }
    public string? Link { get; set; }
}
