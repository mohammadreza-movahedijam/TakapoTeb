using Application.Contract;
using Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Document;

internal sealed class DeleteDocumentHandler :
    IRequestHandler<DeleteDocumentCommand>
{
    readonly IRepository<DocumentEntity> _repository;
    public DeleteDocumentHandler(IRepository<DocumentEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
    {
        DocumentEntity? document=await _repository.GetAsync(g=>g.Id==request.Id,cancellationToken);
        if (document == null) 
        {
            throw new InternalException(Message.NotFoundOnDb);
        }
        document.IsDeleted = true;
        await _repository.UpdateAsync(document,cancellationToken);
    }
}
