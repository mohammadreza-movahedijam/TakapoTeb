using Application.Commands.Slider;
using MediatR;

namespace Application.Queries.Slider;

public sealed record GetSliderQuery : IRequest<SliderDto>
{
    public Guid Id { get; set; }
    public GetSliderQuery(in Guid Id)
    {
        this.Id = Id;
    }
}
