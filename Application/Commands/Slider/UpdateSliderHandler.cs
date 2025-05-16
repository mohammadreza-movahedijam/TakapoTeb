using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Slider;

internal sealed class UpdateSliderHandler :
    IRequestHandler<DeleteSliderCommand>
{
    readonly IRepository<SliderEntity> _sliderRepository;
    public UpdateSliderHandler(IRepository<SliderEntity> sliderRepository)
    {
        _sliderRepository = sliderRepository;
    }
    public async Task Handle(DeleteSliderCommand request,
        CancellationToken cancellationToken)
    {
        SliderEntity? slider = await _sliderRepository
            .GetAsync(g => g.Id == request.Slider.Id, cancellationToken);
        if (slider == null) 
        {
            throw new InternalException(Message.NotFoundOnDb);
        }
        request.Slider.Adapt(slider);
        if (request.Slider.File is not null) 
        {
            slider.ImagePath = request.Slider!.File!.UploadImage("Slider");
            request.Slider.ImagePath!.RemoveImage("Slider");
        }
        await _sliderRepository.UpdateAsync(slider, cancellationToken); 
    }
}
