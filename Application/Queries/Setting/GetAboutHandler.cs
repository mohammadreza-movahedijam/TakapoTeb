using Application.Contract;
using Application.Queries.Setting.ViewModels;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Setting;

internal sealed class GetAboutHandler : IRequestHandler<GetAboutQuery, AboutSectionViewModel>
{
    readonly IRepository<SettingEntity> _settingEntityRepository;
    public GetAboutHandler(IRepository<SettingEntity> settingEntityRepository)
    {
        _settingEntityRepository = settingEntityRepository;
    }
    public async Task<AboutSectionViewModel> Handle(GetAboutQuery request, CancellationToken cancellationToken)
    {
        IQueryable<SettingEntity> query = _settingEntityRepository.GetByQuery();
        AboutSectionViewModel? model = await query.Select(s => new AboutSectionViewModel()
        {
            AboutEn = s.AboutEn,
            AboutFa = s.AboutFa,
            AboutImagePath = s.AboutImagePath,
            YearsExperience = s.YearsExperience
        }).FirstOrDefaultAsync();
        return model!;
    }
}
