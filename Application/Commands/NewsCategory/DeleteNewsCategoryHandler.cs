using Application.Commands.BlogCategory;
using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.NewsCategory;

internal class DeleteNewsCategoryHandler
:
    IRequestHandler<DeleteNewsCategoryCommand>
{
    readonly IRepository<NewsCategoryEntity> _repository;
    public DeleteNewsCategoryHandler
        (IRepository<NewsCategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteNewsCategoryCommand request,
        CancellationToken cancellationToken)
    {
        NewsCategoryEntity?
                   category = await _repository.
                  GetAsync(g => g.Id == request.Id, cancellationToken);
        if (category == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }

        category.IsDeleted = true;
        await _repository.UpdateAsync(category, cancellationToken);
    }
}

