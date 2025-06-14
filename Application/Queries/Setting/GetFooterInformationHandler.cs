using Application.Contract;
using Application.Queries.Setting.ViewModels;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Setting;

internal sealed class GetFooterInformationHandler :
    IRequestHandler<GetFooterInformationQuery, FooterInformationViewModel>
{
    readonly IRepository<SettingEntity> _settingEntityRepository;
    public GetFooterInformationHandler(IRepository<SettingEntity> settingEntityRepository)
    {
        _settingEntityRepository = settingEntityRepository;
    }
    public async Task<FooterInformationViewModel> Handle(GetFooterInformationQuery request, CancellationToken cancellationToken)
    {
        IQueryable<SettingEntity> query = _settingEntityRepository.GetByQuery();
        FooterInformationViewModel? model = await query.Select(s => new FooterInformationViewModel()
        {
            BottomLogoPath=s.BottomLogoPath,
            DescriptionFa = s.DescriptionFa,
            DescriptionEn = s.DescriptionEn,
            Instagram =s.Instagram,
            Linkedin=s.Linkedin,
            Telegram=s.Telegram,
            WhatsApp = s.WhatsApp   
        }).FirstOrDefaultAsync();
        return model!;
    }
}
