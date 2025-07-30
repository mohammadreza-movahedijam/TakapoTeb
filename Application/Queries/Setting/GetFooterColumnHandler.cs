using Application.Contract;
using Application.Queries.Setting.ViewModels;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Setting;

internal sealed class GetFooterColumnHandler :
    IRequestHandler<GetFooterColumnQuery, FooterColumnViewModel>
{
    readonly IRepository<SettingEntity> _settingRepository;
    public GetFooterColumnHandler(IRepository<SettingEntity> settingRepository)
    {
        _settingRepository = settingRepository;
    }
    public async Task<FooterColumnViewModel> Handle
        (GetFooterColumnQuery request, CancellationToken cancellationToken)
    {
        IQueryable<SettingEntity> query = _settingRepository.GetByQuery();
        SettingEntity? setting = await query.FirstOrDefaultAsync();
        FooterColumnViewModel model=setting.Adapt<FooterColumnViewModel>();
        return model!;
    }
}
