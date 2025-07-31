using Application.Common;
using Application.Contract;
using Application.Queries.News;
using MediatR;

namespace Application.Queries.NewsCategory;

public sealed record GetNewsCategoriesQuery :
    IRequest<PaginatedList<NewsCategoryViewModel>>
{
    public IPagination? Pagination { get; set; }
}
