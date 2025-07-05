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
using System.Threading.Tasks;

namespace Application.Queries.Article;

internal sealed class GetArticleDetailHandler :
    IRequestHandler<GetArticleDetailQuery, ArticleDetailViewModel>
{
    readonly IRepository<ArticleEntity> _repository;
    public GetArticleDetailHandler(IRepository<ArticleEntity> repository)
    {
        _repository = repository;
    }
    public async Task<ArticleDetailViewModel> Handle(GetArticleDetailQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ArticleEntity> query = 
            _repository.GetByQuery();

        query = query.Include(i => i.Category);
        var model= await query.Where(w=>w.Id == request.Id)
            .Select(s=>new ArticleDetailViewModel()
            {
                CategoryTitleEn = s.Category!.TitleEn,
                CategoryTitleFa = s.Category.TitleFa,
                Id = s.Id,
                TitleFa = s.TitleFa,
                TitleEn = s.TitleEn,
                ImagePath = s.ImagePath,
                TextEn = s.SummaryEn,
                TextFa = s.SummaryFa,
                PublishDateFa = s.PublishDate.PersianDate()!,
                PublishDateEn = s.PublishDate.GregorianDate(),

            }).SingleOrDefaultAsync();
        return model!;
    }
}
