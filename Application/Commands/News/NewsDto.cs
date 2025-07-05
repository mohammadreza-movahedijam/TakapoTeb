using Domain.Types;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.News;

public sealed record NewsDto
{
    public Guid Id { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? ImagePath { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public TopicType TopicType { get; set; }
    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
    public string? ReferencesLink { set; get; }
}
