using Domain.Types;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Catalog;

public sealed record GetBookOrCatalogQuery:
    IRequest<IReadOnlyList<CatalogDetailViewModel>>
{
    public FileType Type {  get; set; }
}
