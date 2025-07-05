using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.News;

internal sealed class GetLastNewsHandler :
    IRequestHandler<GetLastNewsQuery, IReadOnlyList<NewsViewModel>>
{
    readonly IRepository<NewsEntity> _repository;
    public GetLastNewsHandler(IRepository<NewsEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<NewsViewModel>> Handle
        (GetLastNewsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<NewsEntity> query = _repository.GetByQuery();
        return await query.OrderBy(b => b.CreateAt)
            .Take(6).Select(s=> new NewsViewModel()
            {
                Id = s.Id,
                ImagePath = s.ImagePath,
                TitleEn=s.TitleEn,
                TitleFa=s.TitleFa,
                TopicTypeFa=s.TopicType.GetEnumName(),
                TopicTypeEn=s.TopicType.GetEnumShortName(),
            }).ToListAsync();
    }
}
