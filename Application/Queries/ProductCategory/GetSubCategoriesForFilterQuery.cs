using Application.Queries.ProductCategory.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ProductCategory;

public sealed record GetSubCategoriesForFilterQuery
    :IRequest<IReadOnlyList<CategoryDetailViewModel>>
{
}
