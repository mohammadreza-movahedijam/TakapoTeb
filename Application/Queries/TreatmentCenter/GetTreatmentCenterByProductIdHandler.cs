using Application.Contract;
using Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.TreatmentCenter;

internal sealed class GetTreatmentCenterByProductIdHandler :
    IRequestHandler<GetTreatmentCenterByProductIdQuery,
        IReadOnlyList<TreatmentCenterViewModel>>
{
    readonly IRepository<TreatmentCenterEntity> _repository;
    public GetTreatmentCenterByProductIdHandler
        (IRepository<TreatmentCenterEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<TreatmentCenterViewModel>> 
        Handle(GetTreatmentCenterByProductIdQuery request, CancellationToken cancellationToken)
    {
        IQueryable<TreatmentCenterEntity> query = _repository.GetByQuery();
        query = query.Where(w => w.ProductId == request.ProductId);

        return await query.Select(s=>new TreatmentCenterViewModel()
        {
            Id = s.Id,
            Latitude = s.Latitude,
            Longitude = s.Longitude,
        }).ToListAsync();
    }
}
