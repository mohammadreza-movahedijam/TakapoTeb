using Application.Contract;
using Application.Queries.Image;
using Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Document;

internal sealed class GetProductDocumentsByIdHandler :
    IRequestHandler<GetProductDocumentsByIdQuery, IReadOnlyList<DocumentViewModel>>
{
    readonly IRepository<DocumentEntity> _repository;
    public GetProductDocumentsByIdHandler(IRepository<DocumentEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<DocumentViewModel>>
        Handle(GetProductDocumentsByIdQuery request, CancellationToken cancellationToken)
    {
        IQueryable<DocumentEntity> query = _repository.GetByQuery();
        return await query.Where(w => w.ProductId == request.ProductId).
            Select(s => new DocumentViewModel()
        {
            Id = s.Id,
            FilePath = s.FilePath,
            TitleEn = s.TitleEn,
            TitleFa = s.TitleFa,
        }).ToListAsync();
    }
}
