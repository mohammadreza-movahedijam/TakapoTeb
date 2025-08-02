using Application.Contract;
using Application.Queries.Setting.ViewModels;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Setting;

internal sealed class GetLicenseLogoHandler :
    IRequestHandler<GetLicenseLogoQuery, string>
{
    readonly IRepository<SettingEntity> _repository;
    public GetLicenseLogoHandler(IRepository<SettingEntity> repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(GetLicenseLogoQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<SettingEntity> query = _repository.GetByQuery();
        string? model = await query
            .Select(s => s.LicenseLogo).FirstOrDefaultAsync();
        return model!;
    }
}
