using Application.Commands.BlogCategory;
using MediatR;

namespace Application.Queries.BlogCategory;

public sealed record GetBlogCategoryQuery : IRequest<BlogCategoryDto>
{
    public Guid Id { get; set; }
    public GetBlogCategoryQuery(in Guid Id)
    {
        this.Id = Id;
    }
}
