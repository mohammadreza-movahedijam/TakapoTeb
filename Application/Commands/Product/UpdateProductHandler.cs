using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Product;

internal sealed class UpdateProductHandler :
    IRequestHandler<UpdateProductCommand>
{
    readonly IRepository<ProductEntity> _repository;
    public UpdateProductHandler(IRepository<ProductEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        ProductEntity? product=await _repository.GetAsync(g=>g.Id==request.Product.Id, cancellationToken);
        if (product == null) 
        {
            throw new InternalException(Message.InternalError);
        }
        request.Product.Adapt(product);
        if (request.Product.ImageFile != null) 
        {
            product.ImagePath = request.Product.ImageFile.UploadImage("Product");
            request.Product.ImagePath!.RemoveImage("Product");
        }
        await _repository.UpdateAsync(product, cancellationToken);
    }
}
