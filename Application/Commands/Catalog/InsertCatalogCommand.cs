using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Catalog;

public sealed record InsertCatalogCommand:IRequest
{
    public CatalogDto? Catalog { get; set; }
}
