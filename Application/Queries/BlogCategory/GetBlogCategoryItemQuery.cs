using Application.Common;
using MediatR;

namespace Application.Queries.BlogCategory;

public sealed record GetBlogCategoryItemQuery :
    IRequest<IReadOnlyList<ItemGeneric<Guid, string>>>
{
    public string? Search { get; set; }
}
