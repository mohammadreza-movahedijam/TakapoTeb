using Application.Common;
using Application.Contract;
using Domain.Entities.Blog;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.BlogCategory;

internal sealed class GetBlogCategoryItemHandler :
    IRequestHandler<GetBlogCategoryItemQuery, IReadOnlyList<ItemGeneric<Guid, string>>>
{
    readonly IRepository<CategoryEntity> _repository;
    public GetBlogCategoryItemHandler(IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }



    public async Task<IReadOnlyList<ItemGeneric<Guid, string>>>
        Handle(GetBlogCategoryItemQuery request, CancellationToken cancellationToken)
    {
        IQueryable<CategoryEntity> query = _repository.GetByQuery();
        if (!string.IsNullOrEmpty(request.Search))
        {
            query = query.Where(w => w.TitleFa!.Contains(request.Search) ||
            w.TitleEn!.Contains(request.Search));
        }
        return await query.Select(s=>new ItemGeneric<Guid, string>()
        {
            Id = s.Id,
            Title=s.TitleFa +" "+s.TitleEn
        }).ToListAsync();
    }
}
