using Application.Common;
using Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ProductCategory;

public sealed record
    GetProductCategoriesQuery:IRequest<PaginatedList<ProductCategoryViewModel>>
{
    public IPagination Pagination { get; set; }
    public GetProductCategoriesQuery(IPagination Pagination)
    {
        this.Pagination = Pagination;
    }
}
