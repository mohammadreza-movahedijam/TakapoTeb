using Application.Common.Extension;
using Application.Contract;
using Application.Queries.Article.ViewModels;
using Domain.Entities.Blog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Application.Queries.Article;

internal sealed class GetLastArticleHandler :
    IRequestHandler<GetLastArticleQuery, IReadOnlyList<ArticleViewModel>>
{
    readonly IRepository<ArticleEntity> _repository;
    public GetLastArticleHandler(IRepository<ArticleEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<ArticleViewModel>> Handle
        (GetLastArticleQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ArticleEntity> query = _repository.GetByQuery();
        return await query.OrderBy(o => o.PublishDate).Include(i=>i.Category)
            .Take(4)
            .Select(s=>new ArticleViewModel()
            {
                CategoryTitleEn=s.Category!.TitleEn,
                CategoryTitleFa=s.Category.TitleFa,
                Id=s.Id,
                TitleFa=s.TitleFa,
                TitleEn=s.TitleEn,
                ImagePath=s.ImagePath,
                TextEn= s.SummaryEn,
                TextFa = s.SummaryFa,
                PublishDateFa = s.PublishDate.PersianDate()!,
                PublishDateEn=s.PublishDate.ToString(),
            })
            .ToListAsync();
    }
}
