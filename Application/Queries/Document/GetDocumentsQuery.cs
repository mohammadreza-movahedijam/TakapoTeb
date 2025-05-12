using Application.Common;
using Application.Contract;
using MediatR;

namespace Application.Queries.Document;

public sealed record GetDocumentsQuery : IRequest<PaginatedList<DocumentViewModel>>
{
    public Guid ProductId { get; set; }
    public IPagination Pagination { get; set; }
    public GetDocumentsQuery(in Guid ProductId, IPagination Pagination)
    {
        this.ProductId = ProductId;
        this.Pagination = Pagination;
    }
}
