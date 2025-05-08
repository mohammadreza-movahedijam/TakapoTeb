using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ProductCategory;

public sealed record GetProductCategoryItemQuery
    :IRequest<IReadOnlyList<ItemGeneric<Guid,string>>>
{
}
