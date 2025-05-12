using MediatR;

namespace Application.Commands.Document;

public sealed record InsertDocumentCommand : IRequest
{
    public DocumentDto? Document { get; set; }
    public InsertDocumentCommand(DocumentDto? Document)
    {
        this.Document = Document;
    }
}
