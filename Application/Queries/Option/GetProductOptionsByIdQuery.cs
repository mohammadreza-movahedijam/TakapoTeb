using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Option;

public sealed record GetProductOptionsByIdQuery:
    IRequest<IReadOnlyList<OptionViewModel>>
{
    public Guid ProductId { get; set; }
}
