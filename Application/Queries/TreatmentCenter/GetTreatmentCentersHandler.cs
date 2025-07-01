using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using MediatR;

namespace Application.Queries.TreatmentCenter;

internal sealed class GetTreatmentCentersHandler :
    IRequestHandler<GetTreatmentCentersQuery, PaginatedList<TreatmentCenterViewModel>>
{
    readonly IRepository<TreatmentCenterEntity> _repository;
    public GetTreatmentCentersHandler
        (IRepository<TreatmentCenterEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PaginatedList<TreatmentCenterViewModel>> Handle
        (GetTreatmentCentersQuery request, CancellationToken cancellationToken)
    {
        IQueryable<TreatmentCenterEntity> query = _repository.GetByQuery();
        query=query.Where(w=>w.ProductId == request.ProductId);
        PaginatedList<TreatmentCenterViewModel> model = new();
        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.TitleEn!.Contains(request!.Pagination!.keyword)
            || w.TitleFa!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        model = await query.MappingedAsync<TreatmentCenterEntity, TreatmentCenterViewModel>
               (request!.Pagination!.curentPage,
               request!.Pagination!.pageSize, count, total, null);
        return model;
    }
}
