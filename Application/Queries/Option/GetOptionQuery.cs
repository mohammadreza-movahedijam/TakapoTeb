using Application.Commands.Option;
using MediatR;

namespace Application.Queries.Option;

public sealed record GetOptionQuery : IRequest<OptionDto>
{
    public Guid Id { get; set; }
    public GetOptionQuery(in Guid Id)
    {
        this.Id = Id;
    }
}
