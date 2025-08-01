using Application.Commands.Page;
using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Queries.Page;

internal sealed class GetPageHandler :
    IRequestHandler<GetPageQuery, PageDto>
{
    readonly IRepository<PageEntity> _repository;
    public GetPageHandler(IRepository<PageEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PageDto> Handle(GetPageQuery request,
        CancellationToken cancellationToken)
    {
        PageDto pageDto=await _repository
            .GetAsync<PageDto>(g=>g.Id==request.Id,null,cancellationToken);
        if(pageDto is null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return pageDto;
    }
}
