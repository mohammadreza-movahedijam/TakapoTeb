using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;

namespace Application.Commands.Document;

internal sealed class InsertDocumentHandler :
    IRequestHandler<InsertDocumentCommand>
{
    readonly IRepository<DocumentEntity> _repository;
    public InsertDocumentHandler(IRepository<DocumentEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(InsertDocumentCommand request,
        CancellationToken cancellationToken)
    {
        DocumentEntity document =request.Document.Adapt<DocumentEntity>();
        document.FilePath = await request.Document!.File!.UploadFileAsync("Product");
        await _repository.InsertAsync(document,cancellationToken);
    }
}
