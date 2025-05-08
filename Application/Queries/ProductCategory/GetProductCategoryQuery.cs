using Application.Commands.ProductCategory;
using MediatR;
using System;

namespace Application.Queries.ProductCategory;

public sealed record GetProductCategoryQuery:
    IRequest<ProductCategoryDto>
{
    public Guid Id { get; set; }
    public GetProductCategoryQuery(in Guid Id)
    {
        this.Id = Id;
    }
}
