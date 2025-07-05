using Application.Contract;
using Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.TreatmentCenter;

internal sealed class GetTreatmentCenterProductsHandler :
    IRequestHandler<GetTreatmentCenterProductsQuery
        , IReadOnlyList<TreatmentCenterViewModel>>
{
    readonly IRepository<TreatmentCenterEntity> _repository;
    public GetTreatmentCenterProductsHandler
        (IRepository<TreatmentCenterEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<TreatmentCenterViewModel>> Handle(GetTreatmentCenterProductsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<TreatmentCenterEntity> query = _repository.GetByQuery();
       

        return await query.Select(s => new TreatmentCenterViewModel()
        {
            Id = s.Id,
            Latitude = s.Latitude,
            Longitude = s.Longitude,
        }).ToListAsync();
    }
}
