using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Setting;

internal sealed class ChangeSettingHandler :
    IRequestHandler<ChangeSettingCommand>
{
    readonly IRepository<SettingEntity> _settingRepository;
    public ChangeSettingHandler(IRepository<SettingEntity> settingRepository)
    {
        _settingRepository = settingRepository;
    }
    public async Task Handle(ChangeSettingCommand request,
        CancellationToken cancellationToken)
    {
        IQueryable<SettingEntity> query = _settingRepository.GetByQuery();
        SettingEntity? setting = await query.FirstOrDefaultAsync();
        request.Setting.Adapt(setting);
        if (request.Setting.BottomLogoFile != null) 
        {
            setting!.BottomLogoPath = request.Setting.BottomLogoFile.UploadImage("setting");
            request.Setting.BottomLogoPath!.RemoveImage("setting");
        }

        if (request.Setting.TopLogoFile != null)
        {
            setting!.TopLogoPath = request.Setting.TopLogoFile.UploadImage("setting");
            request.Setting.TopLogoPath!.RemoveImage("setting");
        }
        
        if (request.Setting.AboutImageFile != null)
        {
            setting!.TopLogoPath = request.Setting.AboutImageFile.UploadImage("setting");
            request.Setting.AboutImagePath!.RemoveImage("setting");
        }

        await _settingRepository.UpdateAsync(setting!,cancellationToken);
    }
}
