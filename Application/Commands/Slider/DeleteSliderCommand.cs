using MediatR;

namespace Application.Commands.Slider;

public sealed record DeleteSliderCommand : IRequest
{
    public Guid Id { get; set; }
    public DeleteSliderCommand(in Guid Id)
    {
        this.Id = Id;
    }
}
