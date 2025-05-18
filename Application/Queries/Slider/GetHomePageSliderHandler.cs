using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Slider;

internal sealed class GetHomePageSliderHandler :
    IRequestHandler<GetHomePageSliderQuery, IReadOnlyList<SliderViewModel>>
{
    readonly IRepository<SliderEntity> _repository;
    public GetHomePageSliderHandler(IRepository<SliderEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<SliderViewModel>>
        Handle(GetHomePageSliderQuery request, CancellationToken cancellationToken)
    {
        IQueryable<SliderEntity> query = _repository.GetByQuery();
        IReadOnlyList<SliderViewModel> list =
            await query.Select(s=>new SliderViewModel()
            {
                Alt=s.Alt,
                Id=s.Id,
                ImagePath=s.ImagePath,
                Link = s.Link,
                Title=s.Title,
            }).ToListAsync();
        return list;
    }
}
