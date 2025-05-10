using Application.Commands.Product;
using MediatR;

namespace Application.Queries.Product;

public sealed record GetProductQuery : IRequest<ProductDto>
{
    public Guid Id { get; set; }
    public GetProductQuery(in Guid Id)
    {
        this.Id = Id;
    }
}
