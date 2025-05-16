using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;

namespace Application.Commands.Slider;

internal sealed class InsertSliderHandler :
    IRequestHandler<InsertSliderCommand>
{
    readonly IRepository<SliderEntity> _sliderRepository;
    public InsertSliderHandler(IRepository<SliderEntity> sliderRepository)
    {
        _sliderRepository = sliderRepository;
    }
    public async Task Handle(InsertSliderCommand request,
        CancellationToken cancellationToken)
    {
        SliderEntity slider = request.Slider.Adapt<SliderEntity>();
        slider.ImagePath = request.Slider!.File!.UploadImage("Slider");
        await _sliderRepository.InsertAsync(slider,cancellationToken);
    }
}
