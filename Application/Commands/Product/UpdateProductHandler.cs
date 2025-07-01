using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Product;

internal sealed class UpdateProductHandler :
    IRequestHandler<UpdateProductCommand>
{
    readonly IContext _context;
    readonly IRepository<RelatedEntity> _relatedRepository;
    readonly IRepository<ProductEntity> _repository;
    public UpdateProductHandler(IRepository<ProductEntity> repository,
        IRepository<RelatedEntity> relatedRepository,
        IContext context)
    {
        _relatedRepository=relatedRepository;
        _repository = repository;
        _context = context;
    }
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {

        IExecutionStrategy strategy = _context.CreateExecutionStrategy();


        await strategy.ExecuteAsync(async() =>
        {
            using (IDbContextTransaction transaction = await _context.BeginTransactionAsync())
            {

                try
                {
                    IQueryable<RelatedEntity> query = _relatedRepository.GetByQuery();
                    ProductEntity? product = await _repository.
                    GetAsync(g => g.Id == request.Product.Id, cancellationToken);
                    if (product == null)
                    {
                        throw new InternalException(CustomMessage.InternalError);
                    }
                    request.Product.Adapt(product);
                    if (product.CategoryId is null)
                    {
                        product.CategoryId = request.Product.OldCategoryId;
                    }
                    if (request.Product.ImageFile != null)
                    {
                        product.ImagePath = request.Product.ImageFile.UploadImage("Product");
                        request.Product.ImagePath!.RemoveImage("Product");
                    }
                    await _repository.UpdateAsync(product, cancellationToken);

                    await query.Where(w=>w.ProductId==request.Product.Id)
                    .ExecuteDeleteAsync(cancellationToken);
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
