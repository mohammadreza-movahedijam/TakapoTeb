using MediatR;

namespace Application.Commands.Slider;

public sealed record DeleteSliderCommand :
    IRequest
{
    public SliderDto Slider { get; set; }
    public DeleteSliderCommand(SliderDto Slider)
    {
        this.Slider = Slider;
    }
}
