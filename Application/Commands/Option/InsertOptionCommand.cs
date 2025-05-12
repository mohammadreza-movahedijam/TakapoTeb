using MediatR;

namespace Application.Commands.Option;

public sealed record InsertOptionCommand : IRequest
{
    public OptionDto ProductOption { get; set; }
    public InsertOptionCommand(OptionDto ProductOption)
    {
        this.ProductOption = ProductOption;
    }
}
