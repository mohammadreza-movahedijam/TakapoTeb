using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Feature;

internal sealed class GetFeatureItemHandler :
    IRequestHandler<GetFeatureItemQuery, FeatureViewModel>
{
    readonly IRepository<FeatureEntity> _featureEntityRepository;
    public GetFeatureItemHandler(IRepository<FeatureEntity> featureEntityRepository)
    {
        _featureEntityRepository    = featureEntityRepository;
    }
    public async Task<FeatureViewModel> Handle
        (GetFeatureItemQuery request, CancellationToken cancellationToken)
    {
        IQueryable<FeatureEntity> query = _featureEntityRepository.GetByQuery();
        FeatureEntity? feature= await query.FirstOrDefaultAsync();
        return feature.Adapt<FeatureViewModel>();   
    }
}
