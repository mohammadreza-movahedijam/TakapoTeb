using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.ProductCategory;

internal sealed class InsertProductCategoryHandler :
    IRequestHandler<InsertProductCategoryCommand,bool>
{
    readonly IRepository<CategoryEntity> _repository;
    public InsertProductCategoryHandler
        (IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task<bool> Handle(InsertProductCategoryCommand
        request, CancellationToken cancellationToken)
    {
        bool IsExist=false;
        IQueryable<CategoryEntity> quey = _repository.GetByQuery();
        if (request.ProductCategory.ParentProductCategoryId == Guid.Empty) 
        {
            IsExist = await quey.AnyAsync(a => a.ParentProductCategoryId == null &&
            a.DisplayPriority == request.ProductCategory.DisplayPriority);
        }
        else
        {
            IsExist = await quey.AnyAsync(a => a.ParentProductCategoryId == request.ProductCategory.ParentProductCategoryId &&
           a.DisplayPriority == request.ProductCategory.DisplayPriority);
        }

        if (IsExist) 
        {
            return false;
        }
        else
        {
            CategoryEntity productCategory =
          request.ProductCategory.Adapt<CategoryEntity>();

            productCategory.ImagePath = request.ProductCategory!.ImageFile!.
                UploadImage("ProductCategory");

            await _repository.InsertAsync(productCategory, cancellationToken);
            return true;
        }
    }
}
