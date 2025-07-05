using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NReco.PdfGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.News;

internal sealed class GetNewsByTopicHandler :
    IRequestHandler<GetNewsByTopicQuery, ValueTuple<IReadOnlyList<NewsViewModel>, int,int>>
{
    readonly IRepository<NewsEntity> _repository;
    public GetNewsByTopicHandler(IRepository<NewsEntity> repository)
    {
        _repository = repository;
    }


    public async Task<(IReadOnlyList<NewsViewModel>,int, int)> 
        Handle(GetNewsByTopicQuery request, CancellationToken cancellationToken)
    {

        TypeAdapterConfig config = new ();
        config.NewConfig<NewsEntity, NewsViewModel>()
            .Map(d => d.CreateAtFa, s => s.CreateAt.PersianDateWithTime())
            .Map(d => d.CreateAtEn, s => s.CreateAt.GregorianDate())
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.ImagePath, s => s.ImagePath)
            .Map(d => d.TitleEn, s => s.TitleEn)
            .Map(d => d.TitleFa, s => s.TitleFa)
            .Map(d => d.TopicTypeEn, s => s.TopicType.GetEnumShortName())
            .Map(d => d.TopicTypeFa, s => s.TopicType.GetEnumName())
         .Compile();


        IQueryable<NewsEntity> query = _repository.GetByQuery();
        
        query=query.Where(w=>w.TopicType==request.TopicType).OrderBy(o=>o.CreateAt);
        int total = query.Count();
        int take = request.part * 6;
        var list = await query.Take(take).ToListAsync();
        IReadOnlyList<NewsViewModel> Convertedlist=
            list.Adapt<List<NewsViewModel>>(config);
        return ValueTuple.Create(Convertedlist, request.part, total);
    }
}
