using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Document;

public sealed record DeleteDocumentCommand:
    IRequest
{
    public Guid Id { get; set; }
    public DeleteDocumentCommand(in Guid Id)
    {
        this.Id = Id;
    }
}
