using Application.Commands.Catalog;
using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Catalog;

internal sealed class GetCatalogHandler :
    IRequestHandler<GetCatalogQuery, CatalogDto>
{
    readonly IRepository<CatalogEntity> _repository;
    public GetCatalogHandler(IRepository<CatalogEntity> repository)
    {
        _repository = repository;
    }
    public async Task<CatalogDto> Handle(GetCatalogQuery request,
        CancellationToken cancellationToken)
    {
        CatalogDto catalog = await _repository
            .GetAsync<CatalogDto>(g => g.Id == request.Id, null,cancellationToken);
        if(catalog == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return catalog;
    }
}
