using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.BlogCategory;

public sealed record GetBlogCategoryWithCountArticleQuery:
    IRequest<IReadOnlyList<BlogCategoryViewModel>>
{
}
