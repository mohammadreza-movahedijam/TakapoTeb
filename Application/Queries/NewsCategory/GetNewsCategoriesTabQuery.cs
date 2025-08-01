using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.NewsCategory;

public sealed record GetNewsCategoriesTabQuery:
    IRequest<IReadOnlyList<NewsCategoryViewModel>>
{
}
