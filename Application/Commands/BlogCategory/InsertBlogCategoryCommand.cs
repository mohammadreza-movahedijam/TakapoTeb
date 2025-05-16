using MediatR;

namespace Application.Commands.BlogCategory;

public sealed record InsertBlogCategoryCommand : IRequest
{
    public BlogCategoryDto BlogCategory { get; set; }
    public InsertBlogCategoryCommand(BlogCategoryDto? BlogCategory)
    {
        this.BlogCategory = BlogCategory;
    }
}
