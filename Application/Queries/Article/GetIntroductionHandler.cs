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

namespace Application.Queries.Article;

internal sealed class GetIntroductionHandler :
    IRequestHandler<GetIntroductionQuery, IntroductionVieModel>
{
    readonly IRepository<SettingEntity> _repository;
    public GetIntroductionHandler(IRepository<SettingEntity> repository)
    {
        _repository = repository;
    }

    public async Task<IntroductionVieModel> Handle
        (GetIntroductionQuery request, CancellationToken cancellationToken)
    {
        IQueryable<SettingEntity> query = _repository.GetByQuery();
        IntroductionVieModel? model = await query.Select(s => new IntroductionVieModel()
        {
            LinkVideo = s.Video
        }).FirstOrDefaultAsync();
        return model!;
    }
}
