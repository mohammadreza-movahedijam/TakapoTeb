using MediatR;

namespace Application.Commands.Slider;

public sealed record UpdateSliderCommand :
    IRequest
{
    public SliderDto Slider { get; set; }
    public UpdateSliderCommand(SliderDto Slider)
    {
        this.Slider = Slider;
    }
}
