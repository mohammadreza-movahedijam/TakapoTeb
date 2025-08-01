using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.NewsCategory;

public sealed record GetNewsCategoryItemQuery
:IRequest<IReadOnlyList<ItemGeneric<Guid, string>>>
{
    public string? Search { get; set; }
}
