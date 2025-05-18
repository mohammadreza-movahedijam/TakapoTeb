using Application.Commands.Setting;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Setting;

internal sealed class GetSettingHandler : IRequestHandler<GetSettingQuery, SettingDto>
{
    readonly IRepository<SettingEntity> _repository;
    public GetSettingHandler(IRepository<SettingEntity> repository)
    {
        _repository = repository;
    }
    public async Task<SettingDto> Handle(GetSettingQuery request, CancellationToken cancellationToken)
    {
        IQueryable<SettingEntity> query = _repository.GetByQuery();
        SettingEntity? setting = await query.FirstOrDefaultAsync();
        return setting.Adapt<SettingDto>();
    }
}
