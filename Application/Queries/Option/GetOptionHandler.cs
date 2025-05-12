using Application.Commands.Option;
using Application.Contract;
using Domain.Entities.Product;
using MediatR;

namespace Application.Queries.Option;

internal sealed class GetOptionHandler :
    IRequestHandler<GetOptionQuery, OptionDto>
{
    readonly IRepository<OptionEntity> _repository;
    public GetOptionHandler(IRepository<OptionEntity> repository)
    {
        _repository = repository;
    }
    public async Task<OptionDto> Handle(GetOptionQuery request,
        CancellationToken cancellationToken)
    {
        OptionDto productOptionDto=
            await _repository.GetAsync<OptionDto>
            (g=>g.Id==request.Id,null,cancellationToken);
        if (productOptionDto is null) 
        {
            throw new InternalException(Message.NotFoundOnDb);
        }

        return productOptionDto;
    }
}
