using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Transactions;

namespace Application.Commands.Product;

internal sealed class InsertProductHandler : IRequestHandler<InsertProductCommand>
{
    readonly IContext _context;
    readonly IRepository<ProductEntity> _repository;
    readonly IRepository<RelatedEntity> _relatedRepository;
    public InsertProductHandler(IRepository<ProductEntity> repository,
        IRepository<RelatedEntity> relatedRepository, IContext context)
    {
        _relatedRepository = relatedRepository;
        _repository = repository;
        _context = context;
    }
    public async Task Handle(InsertProductCommand request, CancellationToken cancellationToken)
    {
        IExecutionStrategy strategy = _context.CreateExecutionStrategy();

        await strategy.ExecuteAsync(async () =>
        {
            using (IDbContextTransaction transaction = await _context.BeginTransactionAsync())
            {

                try
                {
                    ProductEntity product = request.Product.Adapt<ProductEntity>();
                    product.ImagePath = request.Product.ImageFile!.UploadImage("Product");
                    await _repository.InsertAsync(product, cancellationToken);
                    if (request.Product.RelatedProducts != null && request.Product.RelatedProducts.Any())
                    {
                        List<RelatedEntity> relateds = [];
                        foreach (var item in request.Product.RelatedProducts)
                        {
                            RelatedEntity related = new()
                            {
                                ProductId = product.Id,
                                RelatedId = item
                            };
                            relateds.Add(related);
                        }
                        await _relatedRepository.InsertAsync(relateds, cancellationToken);
                    }
                    await transaction.CommitAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(cancellationToken);
                }
            }
        });
    }
}
