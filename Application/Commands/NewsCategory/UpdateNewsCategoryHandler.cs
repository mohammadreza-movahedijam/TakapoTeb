using Application.Commands.NewsCategory;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.NewsCategory;

internal class UpdateNewsCategoryHandler
 :
    IRequestHandler<UpdateNewsCategoryCommand>
{
    readonly IRepository<NewsCategoryEntity> _repository;
    public UpdateNewsCategoryHandler
        (IRepository<NewsCategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateNewsCategoryCommand request,
        CancellationToken cancellationToken)
    {
        NewsCategoryEntity?
                   category = await _repository.
                   GetAsync(g => g.Id == request.NewsCategory!.Id, cancellationToken);
        if (category == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }

        request.NewsCategory.Adapt(category);
        await _repository.UpdateAsync(category, cancellationToken);
    }
}
