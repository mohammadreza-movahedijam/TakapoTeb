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

internal sealed class InsertNewsCategoryHandler
    :
 IRequestHandler<InsertNewsCategoryCommand>
{
    readonly IRepository<NewsCategoryEntity> _repository;
    public InsertNewsCategoryHandler
        (IRepository<NewsCategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(InsertNewsCategoryCommand request,
        CancellationToken cancellationToken)
    {
        NewsCategoryEntity
            category = request.NewsCategory.
            Adapt<NewsCategoryEntity>();
        await _repository.InsertAsync(category, cancellationToken);
    }
}