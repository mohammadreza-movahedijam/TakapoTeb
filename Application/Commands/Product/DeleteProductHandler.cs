using Application.Contract;
using Domain.Entities.Product;
using MediatR;

namespace Application.Commands.Product;

internal sealed class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
{
    readonly IRepository<ProductEntity> _repository;
    public DeleteProductHandler(IRepository<ProductEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        ProductEntity? product = await _repository.GetAsync(g => g.Id == request.Id, cancellationToken);
        if (product == null)
        {
            throw new InternalException(    CustomMessage.InternalError);
        }
        product.IsDeleted = true;
        await _repository.UpdateAsync(product, cancellationToken);
    }
}
