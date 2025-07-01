using Application.Commands.Product;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Product;

internal sealed class GetProductHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    readonly IRepository<ProductEntity> _repository;
    public GetProductHandler(IRepository<ProductEntity> repository)
    {
        _repository = repository;
    }
    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ProductEntity> query =
           _repository.GetByQuery();

        ProductEntity? ProductEntity = await query.
            Include(i => i.Category).SingleOrDefaultAsync
            (s => s.Id == request.Id, cancellationToken);

        if (ProductEntity is null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        ProductDto product = ProductEntity.Adapt<ProductDto>();
        
        return product;
    }
}
