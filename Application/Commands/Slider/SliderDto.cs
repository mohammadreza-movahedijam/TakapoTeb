using Microsoft.AspNetCore.Http;

namespace Application.Commands.Slider;

public sealed record SliderDto
{
    public Guid? Id { get; set; }
    public IFormFile? File { get; set; }
    public string? ImagePath { get; set; }
    public string? Title { get; set; }
    public string? Alt { get; set; }
    public string? Link { get; set; }
}
