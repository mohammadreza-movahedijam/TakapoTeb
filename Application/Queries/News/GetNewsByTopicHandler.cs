using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.News;

internal sealed class GetNewsByTopicHandler :
    IRequestHandler<GetNewsByTopicQuery, ValueTuple<IReadOnlyList<NewsViewModel>, int, int>>
{
    readonly IRepository<NewsCategoryEntity> _newCategoryRepository;
    readonly IRepository<NewsEntity> _repository;
    public GetNewsByTopicHandler(
        IRepository<NewsCategoryEntity> newCategoryRepository,
        IRepository<NewsEntity> repository)
    {
        _newCategoryRepository = newCategoryRepository;
        _repository = repository;
    }
    

    public async Task<(IReadOnlyList<NewsViewModel>, int, int)>
        Handle(GetNewsByTopicQuery request, CancellationToken cancellationToken)
    {
        Guid Active = Guid.Empty;
        if (string.IsNullOrEmpty(request.NewsCategoryId))
        {
            IQueryable<NewsCategoryEntity> categoryQuery = _newCategoryRepository.GetByQuery();
            Active=await categoryQuery.OrderBy(o=>o.CreatedDate).Select(s=>s.Id).FirstOrDefaultAsync();
        }
        else
        {
            Active=Guid.Parse(request.NewsCategoryId);
        }

        TypeAdapterConfig config = new();
        config.NewConfig<NewsEntity, NewsViewModel>()
            .Map(d => d.CreateAtFa, s => s.CreateAt.PersianDateWithTime())
            .Map(d => d.CreateAtEn, s => s.CreateAt.GregorianDate())
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.ImagePath, s => s.ImagePath)
            .Map(d => d.TitleEn, s => s.TitleEn)
            .Map(d => d.TitleFa, s => s.TitleFa)
            .Map(d => d.TopicTypeEn, s => s.NewsCategory!.TitleEn)
            .Map(d => d.TopicTypeFa, s => s.NewsCategory!.TitleFa)
         .Compile();


        IQueryable<NewsEntity> query = _repository.GetByQuery();

        query = query.Where(w => w.NewsCategoryId == Active)
            .Include(i => i.NewsCategory)
            .OrderBy(o => o.CreateAt);
        int total = query.Count();
        int take = request.part * 6;
        var list = await query.Take(take).ToListAsync();
        IReadOnlyList<NewsViewModel> Convertedlist =
            list.Adapt<List<NewsViewModel>>(config);
        return ValueTuple.Create(Convertedlist, request.part, total);
    }
}
