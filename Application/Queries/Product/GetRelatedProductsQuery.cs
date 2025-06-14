using Application.Queries.Product.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Product;

public sealed record GetRelatedProductsQuery:
    IRequest<IReadOnlyList<RelatedProductViewModel>>
{
    public string? ProductName { get; set; }
    public Guid ProductId { get; set; }
}
