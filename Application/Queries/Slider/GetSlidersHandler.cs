using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.Queries.BlogCategory;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Slider;

internal sealed class GetSlidersHandler :
    IRequestHandler<GetSlidersQuery, PaginatedList<SliderViewModel>>
{
    readonly IRepository<SliderEntity> _sliderRepository;
    public GetSlidersHandler(IRepository<SliderEntity> sliderRepository)
    {
        _sliderRepository = sliderRepository;
    }
    public async Task<PaginatedList<SliderViewModel>> 
        Handle(GetSlidersQuery request, CancellationToken cancellationToken)
    {
        IQueryable<SliderEntity> query = _sliderRepository.GetByQuery();

        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.Alt!.Contains(request!.Pagination!.keyword)
            || w.Title!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); 
        int total = query.Count();

        PaginatedList<SliderViewModel> model =
            await query.MappingedAsync<SliderEntity, SliderViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}
