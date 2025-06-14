using Application.Contract;
using Application.Queries.Setting.ViewModels;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Setting;

internal sealed class GetWayCommunicationHandler :
    IRequestHandler<GetWayCommunicationQuery, WayCommunicationViewModel>
{
    readonly IRepository<SettingEntity> _repository;
    public GetWayCommunicationHandler(IRepository<SettingEntity> repository)
    {
        _repository = repository;
    }
    public async Task<WayCommunicationViewModel> Handle
        (GetWayCommunicationQuery request, CancellationToken cancellationToken)
    {
        IQueryable<SettingEntity> query = _repository.GetByQuery();
        WayCommunicationViewModel? model = await query.Select(s => new WayCommunicationViewModel()
        {
          ContactNumber = s.ContactNumber,
          Instagram= s.Instagram,
          Linkedin = s.Linkedin,
          LocationEn = s.LocationEn,
            LocationFa = s.LocationFa,
          Telegram = s.Telegram,
          WhatsApp = s.WhatsApp,
          WorkingHoursEn = s.WorkingHoursEn,
          WorkingHoursFa = s.WorkingHoursFa
        }).FirstOrDefaultAsync();
        return model!;
    }
}
