
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

internal sealed class GetAcademyHandler :
    IRequestHandler<GetAcademyQuery, AcademyViewModel>
{
    readonly IRepository<SettingEntity> _repository;
    public GetAcademyHandler(IRepository<SettingEntity> repository)
    {
        _repository = repository;
    }

    public async Task<AcademyViewModel> Handle(GetAcademyQuery request, 
        CancellationToken cancellationToken)
    {
        IQueryable<SettingEntity> query = _repository.GetByQuery();
        AcademyViewModel? model = await query.Select(s => new AcademyViewModel()
        {
          AcademyImagePath=s.AcademyImagePath,
          AcademyTextEn = s.AcademyTextEn,
          AcademyTextFa = s.AcademyTextFa,
          AcademyTitleEn = s.AcademyTitleEn,
          AcademyTitleFa = s.AcademyTitleFa,
        }).FirstOrDefaultAsync();
        return model!;
    }
}
