using Application.Queries.ProductCategory.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ProductCategory;

public sealed record GetCategoryDetailQuery:IRequest<CategoryDetailViewModel>
{
    public Guid Id { get; set; }
    public GetCategoryDetailQuery(in Guid Id)
    {
        this.Id = Id;
    }
}
