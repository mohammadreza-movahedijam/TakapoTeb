using Application.Common.CustomException;
using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.ProductCategory;

internal sealed class UpdateProductCategoryHandler :
    IRequestHandler<UpdateProductCategoryCommand,bool>
{
    readonly IRepository<CategoryEntity> _repository;
    public UpdateProductCategoryHandler(IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task<bool> Handle(UpdateProductCategoryCommand request,
        CancellationToken cancellationToken)
    {


        bool IsExist = false;
        IQueryable<CategoryEntity> quey = _repository.GetByQuery();
        if (request.ProductCategory.ParentProductCategoryId == Guid.Empty)
        {
            IsExist = await quey.AnyAsync(a => 
            a.Id !=request.ProductCategory.Id &&
            a.ParentProductCategoryId == null &&
            a.DisplayPriority == request.ProductCategory.DisplayPriority);
        }
        else
        {
            IsExist = await quey.AnyAsync(a =>
             a.Id != request.ProductCategory.Id &&
            a.ParentProductCategoryId == request.ProductCategory.ParentProductCategoryId &&
           a.DisplayPriority == request.ProductCategory.DisplayPriority);
        }
        if (IsExist) 
        {
            return false;
        }
        else
        {
            CategoryEntity? productCategory =
            await _repository.GetAsync(g => g.Id == request.ProductCategory.Id, cancellationToken);
            if (productCategory == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            request.ProductCategory.Adapt(productCategory);
            if (request.ProductCategory.ImageFile != null)
            {
                productCategory.ImagePath = request.ProductCategory!.ImageFile!.
                     UploadImage("ProductCategory");
                request.ProductCategory!.ImagePath!.RemoveImage("ProductCategory");
            }
            await _repository.UpdateAsync(productCategory, cancellationToken);
            return true;
        }














        
    }
}
