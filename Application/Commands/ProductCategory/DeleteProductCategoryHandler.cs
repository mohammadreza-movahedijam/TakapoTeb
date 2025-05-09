using Application.Common.CustomException;
using Application.Contract;
using Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ProductCategory;

internal sealed class DeleteProductCategoryHandler :
    IRequestHandler<DeleteProductCategoryCommand>
{
    readonly IRepository<CategoryEntity> _repository;
    public DeleteProductCategoryHandler(IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
    {
        CategoryEntity? productCategory =
            await _repository.GetAsync(g => g.Id == request.Id, cancellationToken);
        if (productCategory == null)
        {
            throw new InternalException(Message.NotFoundOnDb);
        }
        productCategory.IsDeleted = true;
        await _repository.UpdateAsync(productCategory,cancellationToken);
    }
}
