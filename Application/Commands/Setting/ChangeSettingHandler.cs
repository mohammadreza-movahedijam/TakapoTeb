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
        if (request.Setting.BottomLogoFileFa != null) 
        {
            setting!.BottomLogoPathFa = request.Setting.BottomLogoFileFa.UploadImage("setting");
            request.Setting.BottomLogoPathFa!.RemoveImage("setting");
        }

        if (request.Setting.TopLogoFileFa != null)
        {
            setting!.TopLogoPathFa = request.Setting.TopLogoFileFa.UploadImage("setting");
            request.Setting.TopLogoPathFa!.RemoveImage("setting");
        }


        if (request.Setting.BottomLogoFileEn != null)
        {
            setting!.BottomLogoPathEn = request.Setting.BottomLogoFileEn.UploadImage("setting");
            request.Setting.BottomLogoPathEn!.RemoveImage("setting");
        }

        if (request.Setting.TopLogoFileEn != null)
        {
            setting!.TopLogoPathEn = request.Setting.TopLogoFileEn.UploadImage("setting");
            request.Setting.TopLogoPathEn!.RemoveImage("setting");
        }









        if (request.Setting.AboutPageImageFile != null)
        {
            setting!.AboutImage = request.Setting.AboutPageImageFile.UploadImage("setting");
            request.Setting.AboutImage!.RemoveImage("setting");
        }



        if (request.Setting.AboutImageFile != null)
        {
            setting!.AboutImagePath = request.Setting.AboutImageFile.UploadImage("setting");
            request.Setting.AboutImagePath!.RemoveImage("setting");
        }

        await _settingRepository.UpdateAsync(setting!,cancellationToken);
    }
}
