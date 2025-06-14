using Application.Contract;
using Application.Queries.ProductCategory.ViewModels;
using MediatR;
using Domain.Entities.Product;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.ProductCategory;

internal sealed class GetSubCategoriesForFilterHandler :
    IRequestHandler<GetSubCategoriesForFilterQuery, 
        IReadOnlyList<CategoryDetailViewModel>>
{
    readonly IRepository<CategoryEntity> _repository;
    public GetSubCategoriesForFilterHandler(IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<CategoryDetailViewModel>> Handle
        (GetSubCategoriesForFilterQuery request, CancellationToken cancellationToken)
    {
        IQueryable<CategoryEntity> query = _repository.GetByQuery();
        return await query.Select(s=> new CategoryDetailViewModel() { 
        Id = s.Id,
        TitleEn=s.TitleEn,
        TitleFa=s.TitleFa,
        })
            .ToListAsync();
    }
}
