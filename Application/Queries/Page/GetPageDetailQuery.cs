using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Page;

public sealed record GetPageDetailQuery:IRequest<PageDetailViewModel>
{
    public Guid Id { get; set; }
}
