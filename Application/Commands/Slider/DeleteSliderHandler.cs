using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Commands.Slider;

internal sealed class DeleteSliderHandler :
    IRequestHandler<DeleteSliderCommand>
{
    readonly IRepository<SliderEntity> _sliderRepository;
    public DeleteSliderHandler(IRepository<SliderEntity> sliderRepository)
    {
        _sliderRepository = sliderRepository;
    }
    public async Task Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
    {
        SliderEntity? slider = await _sliderRepository
            .GetAsync(g => g.Id == request.Id, cancellationToken);
        if (slider == null)
        {
            throw new InternalException(Message.NotFoundOnDb);
        }
        slider.IsDeleted = true;
        await _sliderRepository.UpdateAsync(slider, cancellationToken);
    }
}
