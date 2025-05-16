using MediatR;

namespace Application.Commands.BlogCategory;

public sealed record UpdateBlogCategoryCommand :
    IRequest
{
    public BlogCategoryDto BlogCategory { get; set; }
    public UpdateBlogCategoryCommand(BlogCategoryDto BlogCategory)
    {
        this.BlogCategory = BlogCategory;
    }
}
