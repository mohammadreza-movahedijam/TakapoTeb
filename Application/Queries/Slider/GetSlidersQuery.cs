using Application.Common;
using Application.Contract;
using MediatR;

namespace Application.Queries.Slider;

public sealed record GetSlidersQuery :
    IRequest<PaginatedList<SliderViewModel>>
{
    public IPagination Pagination { get; set; }
    public GetSlidersQuery(IPagination Pagination)
    {
        this.Pagination = Pagination;
    }
}

