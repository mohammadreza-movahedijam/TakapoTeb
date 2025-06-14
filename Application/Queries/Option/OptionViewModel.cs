namespace Application.Queries.Option;

public sealed record OptionViewModel
{
    public Guid Id { get; set; }
    public string? TitleFa { set; get; }
    public string? TitleEn { set; get; }
    public string? ImagePath { set; get; }

    public string? DescriptionFa { set; get; }
    public string? DescriptionEn { set; get; }
}
