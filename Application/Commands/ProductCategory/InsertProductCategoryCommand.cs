using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ProductCategory;

public sealed record InsertProductCategoryCommand:IRequest
{
    public ProductCategoryDto ProductCategory {  get; set; }
    public InsertProductCategoryCommand(ProductCategoryDto ProductCategory)
    {
        this.ProductCategory = ProductCategory;
    }
}
