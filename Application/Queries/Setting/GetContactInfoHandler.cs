using Application.Contract;
using Application.Queries.Setting.ViewModels;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Setting;

internal sealed class GetContactInfoHandler : IRequestHandler<GetContactInfoQuery, ContactUsViewModel>
{
    readonly IRepository<SettingEntity> _settingEntityRepository;
    public GetContactInfoHandler(IRepository<SettingEntity> settingEntityRepository)
    {
        _settingEntityRepository = settingEntityRepository;
    }
    public async Task<ContactUsViewModel> Handle
        (GetContactInfoQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<SettingEntity> query = _settingEntityRepository.GetByQuery();
        ContactUsViewModel? model = await query.Select(s => new ContactUsViewModel()
        {
           ContactNumber = s.ContactNumber,
           Email=s.Email,
           Latitude = s.Latitude,   
           Longitude = s.Longitude,
           LocationEn   =s.LocationEn,
           LocationFa =s.LocationFa,
        }).FirstOrDefaultAsync();

     

        return model!;
    }
}
