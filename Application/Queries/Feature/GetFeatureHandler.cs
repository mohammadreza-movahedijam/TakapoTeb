using Application.Commands.Feature;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Feature;

internal sealed class GetFeatureHandler :
    IRequestHandler<GetFeatureQuery, FeatureDto>
{
    readonly IRepository<FeatureEntity> _repository;
    public GetFeatureHandler(IRepository<FeatureEntity> repository)
    {
        _repository = repository;
    }
    public async Task<FeatureDto> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
    {
        IQueryable<FeatureEntity> query =  _repository.GetByQuery();
        FeatureEntity? featur = await query.FirstOrDefaultAsync(cancellationToken);
        return featur.Adapt<FeatureDto>();
    }
}
