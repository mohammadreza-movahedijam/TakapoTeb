using Application.Contract;
using Application.Queries.Setting.ViewModels;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Setting;

internal sealed class GetAboutPageHandler :
    IRequestHandler<GetAboutPageQuery, AboutViewModel>
{
    readonly IRepository<SettingEntity> _settingRepository;
    public GetAboutPageHandler(IRepository<SettingEntity> settingRepository)
    {
        _settingRepository = settingRepository;
    }
    public async Task<AboutViewModel> Handle(GetAboutPageQuery request, 
        CancellationToken cancellationToken)
    {
        IQueryable<SettingEntity> query = _settingRepository.GetByQuery();
        AboutViewModel? model = await query.Select(s => new AboutViewModel()
        {
            AboutImage = s.AboutImage,
            AboutTitleEn = s.AboutTitleEn,
            AboutTitleFa = s.AboutTitleFa,
            AboutDescriptionEn = s.AboutDescriptionEn,
            AboutDescriptionFa = s.AboutDescriptionFa
        }).FirstOrDefaultAsync();
        return model!;
    }
}
