using Application.Contract;
using Application.Queries.Setting.ViewModels;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Setting;

internal sealed class GetLogoHandler :
    IRequestHandler<GetLogoQuery, LogoViewModel>
{
    readonly IRepository<SettingEntity> _repository;
    public GetLogoHandler(IRepository<SettingEntity> repository)
    {
        _repository = repository;
    }
    public async Task<LogoViewModel> Handle(GetLogoQuery request, CancellationToken cancellationToken)
    {
        IQueryable<SettingEntity> query = _repository.GetByQuery();
        LogoViewModel? model = await query.Select(s => new LogoViewModel()
        {
            LogoEn = s.TopLogoPathEn,
            LogoFa = s.TopLogoPathFa
        }).FirstOrDefaultAsync();
        return model!;
    }
}
