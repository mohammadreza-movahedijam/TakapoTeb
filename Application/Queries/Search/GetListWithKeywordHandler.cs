using Application.Contract;
using Domain.Entities.Blog;
using Domain.Entities.Product;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Search;

internal sealed class GetListWithKeywordHandler :
    IRequestHandler<GetListWithKeywordQuery, IReadOnlyList<SearchViewModel>>
{
    readonly IRepository<NewsEntity> _newsRepository;
    readonly IRepository<ArticleEntity> _articleRepository;
    readonly IRepository<ProductEntity> _productRepository;

    public GetListWithKeywordHandler(
        IRepository<NewsEntity> newsRepository,
        IRepository<ArticleEntity> articleRepository,
        IRepository<ProductEntity> productRepository
        )
    {
        _articleRepository = articleRepository;
        _newsRepository = newsRepository;
        _productRepository = productRepository;
    }

    public async Task<IReadOnlyList<SearchViewModel>>
        Handle(GetListWithKeywordQuery request, CancellationToken cancellationToken)
    {
        List<SearchViewModel> list = [];
        IQueryable<ArticleEntity> articleQuery = _articleRepository.GetByQuery();
        articleQuery = articleQuery.Where(w => w.TitleEn!.Contains(request.Search!) ||
        w.TitleFa!.Contains(request.Search!));
        var articles=await articleQuery.ToListAsync(cancellationToken);
        if (articles !=null && articles.Any()) 
        {
            foreach (var article in articles)
            {
                SearchViewModel model = new()
                {
                    TitleEn = article.TitleEn,
                    TitleFa = article.TitleFa,
                    Id = article.Id,
                    Image = article.ImagePath,
                    flag = 1
                };
                list.Add(model);
            }

        }

        IQueryable<NewsEntity> newsQuery = _newsRepository.GetByQuery();
        newsQuery = newsQuery.Where(w => w.TitleEn!.Contains(request.Search!) ||
        w.TitleFa!.Contains(request.Search!));
        var news = await newsQuery.ToListAsync(cancellationToken);
        if(news != null && news.Any())
        {
            foreach (var item in news)
            {
                SearchViewModel model = new()
                {
                    Image = item.ImagePath,
                    TitleEn = item.TitleEn,
                    TitleFa = item.TitleFa,
                    Id = item.Id,
                    flag = 2
                };
                list.Add(model);
            }
        }

        IQueryable<ProductEntity> productQuery = _productRepository.GetByQuery();
        productQuery = productQuery.Where(w => w.TitleEn!.Contains(request.Search!) ||
        w.TitleFa!.Contains(request.Search!));
        var products = await productQuery.ToListAsync(cancellationToken);
        if(products != null && products.Any())
        {
            foreach (var product in products)
            {
                SearchViewModel model = new()
                {
                    Image = product.ImagePath,
                    TitleEn = product.TitleEn,
                    TitleFa = product.TitleFa,
                    Id = product.Id,
                    flag = 3
                };
                list.Add(model);
            }
        }
        return list;
    }
}
