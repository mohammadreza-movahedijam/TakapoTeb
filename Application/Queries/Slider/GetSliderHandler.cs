using Application.Commands.Slider;
using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Slider;

internal sealed class GetSliderHandler :
    IRequestHandler<GetSliderQuery, SliderDto>
{
    readonly IRepository<SliderEntity> _sliderRepository;
    public GetSliderHandler(IRepository<SliderEntity> sliderRepository)
    {
        _sliderRepository = sliderRepository;
    }
    public async Task<SliderDto> Handle(GetSliderQuery request, 
        CancellationToken cancellationToken)
    {
        SliderDto slider=await _sliderRepository.
            GetAsync<SliderDto>(g=>g.Id==request.Id,null,cancellationToken);
        if (slider == null)
        {
            throw new InternalException(Message.NotFoundOnDb);
        }
        return slider;
    }
}
