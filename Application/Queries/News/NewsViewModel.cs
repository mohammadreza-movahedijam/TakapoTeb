using Domain.Types;

namespace Application.Queries.News;

public sealed record NewsViewModel
{
    public Guid Id { get; set; }

    public string? ImagePath { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? TopicTypeFa { get; set; }
    public string? TopicTypeEn { get; set; }
    public string? CreateAtFa { get; set; }
    public string? CreateAtEn { get; set; }
}
