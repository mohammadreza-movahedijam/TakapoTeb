using MediatR;

namespace Application.Commands.Slider;

public sealed record InsertSliderCommand : IRequest
{
    public SliderDto? Slider {  get; set; }
    public InsertSliderCommand(SliderDto? Slider)
    {
        this.Slider = Slider;
    }
}
