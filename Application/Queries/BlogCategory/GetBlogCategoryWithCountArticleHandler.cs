using Application.Common;
using Application.Contract;
using Domain.Entities.Blog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.BlogCategory;

internal sealed class GetBlogCategoryWithCountArticleHandler :
    IRequestHandler<GetBlogCategoryWithCountArticleQuery,
        IReadOnlyList<BlogCategoryViewModel>>
{

    readonly IRepository<CategoryEntity> _repository;
    public GetBlogCategoryWithCountArticleHandler(IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<BlogCategoryViewModel>>
        Handle(GetBlogCategoryWithCountArticleQuery request, CancellationToken cancellationToken)
    {
        IQueryable<CategoryEntity> query = _repository.GetByQuery();
        query = query.Include(i => i.Articles);
        return await query.Select(s => new BlogCategoryViewModel
        {
            Id = s.Id,
            TitleFa = s.TitleFa ,
            TitleEn = s.TitleEn ,
            Count=s.Articles!.Count()
        }).ToListAsync();
    }
}
