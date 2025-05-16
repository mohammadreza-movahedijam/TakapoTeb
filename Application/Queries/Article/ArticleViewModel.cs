namespace Application.Queries.Article;

public sealed record ArticleViewModel
{
    public Guid Id { get; set; }
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    public string? ImagePath { get; set; }
    public string? CategoryTitleFa { get; set; }

}
