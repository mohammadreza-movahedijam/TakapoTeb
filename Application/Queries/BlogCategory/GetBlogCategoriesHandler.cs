using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using MediatR;
using Domain.Entities.Blog;

namespace Application.Queries.BlogCategory;

internal sealed class GetBlogCategoriesHandler :
    IRequestHandler<GetBlogCategoriesQuery, PaginatedList<BlogCategoryViewModel>>
{

    readonly IRepository<CategoryEntity> _repository;
    public GetBlogCategoriesHandler
        (IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }



    public async Task<PaginatedList<BlogCategoryViewModel>>
        Handle(GetBlogCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<CategoryEntity> query = _repository.GetByQuery();

        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.TitleEn!.Contains(request!.Pagination!.keyword)
            || w.TitleFa!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); 
        int total = query.Count();

        PaginatedList<BlogCategoryViewModel> model =
            await query.MappingedAsync<CategoryEntity, BlogCategoryViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}
