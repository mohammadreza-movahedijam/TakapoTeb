using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;

namespace Application.Commands.Catalog;

internal sealed class UpdateCatalogHandler :
    IRequestHandler<UpdateCatalogCommand>
{
    readonly IRepository<CatalogEntity> _repository;
    public UpdateCatalogHandler(IRepository<CatalogEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateCatalogCommand request,
        CancellationToken cancellationToken)
    {
        CatalogEntity? entity = await _repository.GetAsync
            (g => g.Id == request.Catalog!.Id,cancellationToken);

        if (entity == null) 
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        request.Catalog.Adapt(entity);
        if (request.Catalog!.File!=null)
        {
            entity.FilePath = await request.Catalog!.File.UploadFileAsync("Catalog");
            request.Catalog.FilePath!.RemoveFile("Catalog");
        }
        await _repository.UpdateAsync(entity,cancellationToken);
    }
}
