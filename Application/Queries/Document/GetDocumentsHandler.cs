using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.Queries.Option;
using Domain.Entities.Product;
using MediatR;

namespace Application.Queries.Document;

internal sealed class GetDocumentsHandler :
    IRequestHandler<GetDocumentsQuery, PaginatedList<DocumentViewModel>>
{
    readonly IRepository<DocumentEntity> _repository;
    public GetDocumentsHandler(IRepository<DocumentEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PaginatedList<DocumentViewModel>> Handle
        (GetDocumentsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<DocumentEntity> query = _repository.GetByQuery();
        query=query.Where(w=>w.ProductId == request.ProductId); 
        PaginatedList<DocumentViewModel> model = new();
        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.TitleEn!.Contains(request!.Pagination!.keyword)
            || w.TitleFa!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        model = await query.MappingedAsync<DocumentEntity, DocumentViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}
