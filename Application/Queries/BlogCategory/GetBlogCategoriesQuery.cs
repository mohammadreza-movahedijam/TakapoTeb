using Application.Common;
using Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.BlogCategory;

public sealed record GetBlogCategoriesQuery:
    IRequest<PaginatedList<BlogCategoryViewModel>>
{
    public IPagination Pagination { get; set; }
    public GetBlogCategoriesQuery(IPagination Pagination)
    {
        this.Pagination = Pagination;
    }
}
