using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Document;

public sealed record GetProductDocumentsByIdQuery:
    IRequest<IReadOnlyList<DocumentViewModel>>
{
    public Guid ProductId { get; set; }
}
