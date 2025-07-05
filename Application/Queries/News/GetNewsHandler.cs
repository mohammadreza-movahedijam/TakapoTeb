using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.Queries.Feedback;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.News;

internal sealed class GetNewsHandler :
    IRequestHandler<GetNewsQuery, PaginatedList<NewsViewModel>>
{

    readonly IRepository<NewsEntity> _repository;
    public GetNewsHandler(IRepository<NewsEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PaginatedList<NewsViewModel>> Handle
        (GetNewsQuery request, CancellationToken cancellationToken)
    {

        TypeAdapterConfig config = new();
        config.NewConfig<NewsEntity, NewsViewModel>()

            .Map(d => d.Id, s => s.Id)
            .Map(d => d.ImagePath, s => s.ImagePath)
            .Map(d => d.TitleEn, s => s.TitleEn)
            .Map(d => d.TitleFa, s => s.TitleFa)
            .Map(d => d.TopicTypeEn, s => s.TopicType.GetEnumShortName())
            .Map(d => d.TopicTypeFa, s => s.TopicType.GetEnumName())
         .Compile();
        IQueryable<NewsEntity> query = _repository.GetByQuery();

        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.TitleFa!.Contains(request!.Pagination!.keyword)
            || w.TitleEn!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        PaginatedList<NewsViewModel> model =
            await query.MappingedAsync<NewsEntity, NewsViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total, config);
        return model;
    }
}
