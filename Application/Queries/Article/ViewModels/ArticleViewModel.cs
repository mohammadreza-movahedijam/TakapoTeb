namespace Application.Queries.Article.ViewModels
{
    
        public sealed record ArticleViewModel
        {
            public Guid Id { get; set; }
            public string? TitleFa { get; set; }
            public string? TitleEn { get; set; }
            public string? ImagePath { get; set; }
            public string? CategoryTitleFa { get; set; }
            public string? CategoryTitleEn { get; set; }
            public string? TextEn { get; set; }
            public string? TextFa { get; set; }
            public string? PublishDateFa { get; set; }
            public string? PublishDateEn { get; set; }
        }

    
}

