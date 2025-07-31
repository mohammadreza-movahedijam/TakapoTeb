using Application.Commands.NewsCategory;
using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Queries.NewsCategory;

internal sealed class GetNewsCategoryHandler
 :
    IRequestHandler<GetNewsCategoryQuery, NewsCategoryDto>
{


    readonly IRepository<NewsCategoryEntity> _repository;
    public GetNewsCategoryHandler
        (IRepository<NewsCategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task<NewsCategoryDto>
        Handle(GetNewsCategoryQuery request, CancellationToken cancellationToken)
    {
        NewsCategoryDto?
                   category = await _repository.
                   GetAsync<NewsCategoryDto>(g => g.Id == request.Id, null,
                   cancellationToken);
        if (category == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return category;
    }
}

