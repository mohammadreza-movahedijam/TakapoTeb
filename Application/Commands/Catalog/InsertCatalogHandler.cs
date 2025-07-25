using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;

namespace Application.Commands.Catalog;

internal sealed class InsertCatalogHandler :
    IRequestHandler<InsertCatalogCommand>
{
    readonly IRepository<CatalogEntity> _repository;
    public InsertCatalogHandler(IRepository<CatalogEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(InsertCatalogCommand request,
        CancellationToken cancellationToken)
    {
        CatalogEntity catalog = request.Catalog.Adapt<CatalogEntity>();
        if (request.Catalog!.File != null) 
        {
            catalog.FilePath = await request.Catalog!.File.UploadFileAsync("Catalog");
        }
        await _repository.InsertAsync(catalog,cancellationToken);
    }
}
