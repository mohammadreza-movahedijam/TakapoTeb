using MediatR;

namespace Application.Commands.Option;

public sealed record UpdateOptionCommand : IRequest
{
    public OptionDto ProductOption { get; set; }
    public UpdateOptionCommand(OptionDto ProductOption)
    {
        this.ProductOption = ProductOption;
    }
}
