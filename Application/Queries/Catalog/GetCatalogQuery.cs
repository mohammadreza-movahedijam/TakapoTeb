using Application.Commands.Catalog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Catalog;

public sealed record GetCatalogQuery:IRequest<CatalogDto>
{
    public Guid Id { get; set; }
}
