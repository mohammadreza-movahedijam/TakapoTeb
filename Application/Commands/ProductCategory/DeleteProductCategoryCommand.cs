using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ProductCategory;

public sealed record DeleteProductCategoryCommand:IRequest
{
    public Guid Id { get; set; }
    public DeleteProductCategoryCommand(in Guid Id)
    {
        this.Id = Id;
    }
}
